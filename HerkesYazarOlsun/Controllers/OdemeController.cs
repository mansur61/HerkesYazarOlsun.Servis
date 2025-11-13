using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.BLL.Validation;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Servis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdemeController : BaseApiController
    {
        private IKartlarService kartlarSrv;
        private IOdemeService odemeService;
        private IOdemeSponsorlariService odemeSpnsSrv;
        private IUnitOfWork _unitOfWork;
        private OdemeSponsorlariValidator _odemeSponsorlariValidator;
        public OdemeController(IKartlarService _kartlarSrv, IOdemeService odemeService, IOdemeSponsorlariService odemeSpnsSrv,
            IUserAccessor userAccessor, IUnitOfWork unitOfWork, IHttpContextAccessor configuration, OdemeSponsorlariValidator odemeSponsorlariValidator)
            : base(userAccessor, unitOfWork, configuration)
        {
            kartlarSrv = _kartlarSrv;
            this.odemeService = odemeService;
            this.odemeSpnsSrv = odemeSpnsSrv;
            _odemeSponsorlariValidator = odemeSponsorlariValidator;
            _unitOfWork = unitOfWork;
        }
 
        [HttpPost]
        [Route("PostOdeme")]
        public async Task<ServiceResult> PostOdeme(VM_KARTLAR kart)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS);
            var kartEntity = ObjectMapper.Map(kart, new Kartlar());
            var odeme = new Odeme() { KitapId = kart.KitapId, LoginUserId = kart.LoginUserId };

            try
            {
                 _unitOfWork.OpenTransaction();

                // 1. Ödeme ekle
                //var odemeEntity = odemeService.Ekle(odeme, MAIL);

                var odemeEntity = _unitOfWork.GetWriteRepositoryWithNewBaseEntity<Odeme>(odeme);

                // 2. Kart ekle
                kartEntity.Tutar = (long)Convert.ToInt32(kart.Tutar);
                kartEntity.OdemeId = odemeEntity.ID;
                kartEntity.KartTarihi = kart.KartTarihiAy + "/" + kart.KartTarihiYil;

                //kartEntity = kartlarSrv.Ekle(kartEntity, MAIL);

                kartEntity = _unitOfWork.GetWriteRepositoryWithNewBaseEntity<Kartlar>(kartEntity);

                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();

                result.State = MessageResultState.SUCCESS;
                result.Result = kartEntity;
                return result;
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                result.Message = ex.Message;
                result.State = MessageResultState.ERROR;
                return result;
            }
        }


        [HttpPost]
        [Route("SaveSponsorlukBildir")]
        public ServiceResult SaveSponsorlukBildir(VM_ODEME_SPONSORLARI odemeSponsorlar)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS);
            var odemeSpnsEntity = ObjectMapper.Map(odemeSponsorlar, new OdemeSponsorlari());
             
            var sonuc = _odemeSponsorlariValidator.Validate(odemeSponsorlar);

            if (!sonuc!.IsValid)
            {
                foreach (var item in sonuc.Errors)
                {
                    result.Message += item.ErrorMessage + ",";
                }
                result.State = MessageResultState.ERROR;
                return result;
            }

            try
            {
                odemeSpnsEntity = odemeSpnsSrv.Add(odemeSpnsEntity, odemeSponsorlar.tck);

                result.Message = "Sponsor seçiminiz baþarýlý þekilde yapýlmýþtýr. Paylaþtýðýnýz Mail veya Sms bilgiler ile sizlere en kýsa sürede iletiþim saðlanacaktýr.";
                result.State = MessageResultState.SUCCESS;
                return result;
            }
            catch (Exception)
            {
                result.Message = "Sponsor Bildirim durumunda hata meydana geldi.";
                result.State = MessageResultState.ERROR;
            }

            result.Result = odemeSpnsEntity;
            return result;
        }

    }
}