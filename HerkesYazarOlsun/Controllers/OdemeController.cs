
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Validation;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using LinqKit;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdemeController : ControllerBase
    {
        private IKartlarDal kartlarDal;
        private IOdemeDal odemeDal;
        private IOdemeSponsorlariDal odemeSpnsDal;

        public OdemeController(IKartlarDal _kartlarDal, IOdemeDal odemeDal, IOdemeSponsorlariDal odemeSpnsDal)
        {
            kartlarDal = _kartlarDal;
            this.odemeDal = odemeDal;
            this.odemeSpnsDal = odemeSpnsDal;
        }

        [HttpPost]
        [Route("PostOdeme")]
        public ServiceResult PostOdeme(VM_KARTLAR kart)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS);
            var kartEntity = ObjectMapper.Map(kart, new Kartlar());
            var odeme = new Odeme() { KitapId = kart.KitapId, LoginUserId = kart.LoginUserId };


            try
            {
                //Ödeme alt yapýsýna gider. (iyizico vs.) Baþarýlý ise Ödeme tablosuna kayýt atar. isOdeme durumu belilerlenir.
                odeme.isOdeme = true; //örnek olarak ödeme baþarýlý olsun..
                Odeme odemeEntity = odemeDal.Add(odeme, kart.tck);

                kartEntity.Tutar = (long)Convert.ToInt32(kart.Tutar);
                kartEntity.OdemeId = odemeEntity.ID;
                kartEntity.KartTarihi = kart.KartTarihiAy.ToString() + "/" +kart.KartTarihiYil.ToString();
                kartEntity =  kartlarDal.Add(kartEntity, kart.tck);

                result.State = MessageResultState.SUCCESS;
                return result;
            }
            catch (Exception)
            {
                result.Message = "";
                result.State = MessageResultState.ERROR;
            }

            result.Result = kartEntity;
            return result;
        }

        [HttpPost]
        [Route("SaveSponsorlukBildir")]
        public ServiceResult SaveSponsorlukBildir(VM_ODEME_SPONSORLARI odemeSponsorlar)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS);
            var odemeSpnsEntity = ObjectMapper.Map(odemeSponsorlar, new OdemeSponsorlari());

            OdemeSponsorlariValidator validationRules = new OdemeSponsorlariValidator(); 
            var sonuc = validationRules.Validate(odemeSponsorlar);

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
                odemeSpnsEntity = odemeSpnsDal.Add(odemeSpnsEntity, odemeSponsorlar.tck);

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