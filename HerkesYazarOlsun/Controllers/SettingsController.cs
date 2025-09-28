using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.BLL.Validation;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using HerkesYazarOlsun.Servis.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : BaseApiController
    {

        private IAyarlarDal ayrDal;
        private IYayinAyarlariDal yayrDal;
        private readonly ILogger<SettingsController> _logger;
        private IFtpService _ftpService;
        private AyarlarValidator _ayarlarValidator;
        public SettingsController(IAyarlarDal ayrDal, IYayinAyarlariDal _yayrDal, IFtpService ftpService,
            IUserAccessor userAccessor, IUnitOfWork unitOfWork,
            IHttpContextAccessor configuration, ILogger<SettingsController> logger, AyarlarValidator ayarlarValidator)
            : base(userAccessor, unitOfWork, configuration)
        {
            this.ayrDal = ayrDal;
            yayrDal = _yayrDal;
            _logger = logger;
            _ftpService = ftpService;
            _ayarlarValidator = ayarlarValidator;
        }


        [HttpGet]
        [Route("GetAyarlarByLoginId")]
        public Ayarlar? GetProfilByLoginId(long loginId)
        {
            var sonuc = ayrDal.GetAllQueryable(p => p.LoginUserId == loginId).SingleOrDefault();
            return sonuc;
        }

        [HttpGet]
        [Route("GetYyainAyarlari")]
        public YayinAyarlari? GetYayinAyarlari()
        {
            var sonuc = yayrDal.GetList().SingleOrDefault();
            return sonuc;
        }
        private async Task<VM_AYARLAR> ModelIlgiliDosyalariDoldur(VM_AYARLAR input)
        {
            foreach (var item in input.dosyalar)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await item.CopyToAsync(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();

                    // Ön kapak
                    if (!string.IsNullOrEmpty(input.Profile.ProfilResimName) && input.Profile.ProfilResimName == item.FileName)
                    {
                        input.Profile.ProfilResimBase64 = Convert.ToBase64String(fileBytes);
                        input.Profile.ProfilResimURl = "";
                        // FTP'ye yükle
                        var uploadResult = await _ftpService.Upload(item, true);
                        if (uploadResult.IsSuccess)
                            input.Profile.ProfilResimURl = uploadResult.Result.FileName;
                        else
                            _logger.LogWarning("Dosya yüklenemedi: {FileName}", item.FileName + " Hata : " + uploadResult.Message);
                    }

                }
            }

            return input;
        }


        [HttpPost]
        [Route("SaveOrUpdateAyarlar")]
        public async Task<ServiceResult> SaveOrUpdateAyarlar([FromForm] VM_AYARLAR ayarlar)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS);

            var files = ayarlar.dosyalar;
            if (files?.Count != 0 && files != null)
            {
                ayarlar = await ModelIlgiliDosyalariDoldur(ayarlar);
            }


            IAyarlarDal ayarDal = InstanceFactory.GetInstance<IAyarlarDal>().Service;
            IBildirimlerDal bildrmlerDal = InstanceFactory.GetInstance<IBildirimlerDal>().Service;
            IUsersDetailsDal usrDtlsDal = InstanceFactory.GetInstance<IUsersDetailsDal>().Service;
            IProfilDal prfDal = InstanceFactory.GetInstance<IProfilDal>().Service;
            IUsersDal usrDal = InstanceFactory.GetInstance<IUsersDal>().Service;
             
            var sonuc = _ayarlarValidator.Validate(ayarlar);

            if (!sonuc!.IsValid)
            {
                foreach (var item in sonuc.Errors)
                {
                    result.Message += item.ErrorMessage + ",";
                }
                result.State = MessageResultState.WARNING;
                return result;
            }

            try
            {

                //user 
                var usrKayit = usrDal.Get(ayarlar.LoginUserId);
                if (usrKayit == null)
                {
                    usrKayit = usrDal.Ekle(ayarlar.User, MAIL);

                }
                else
                {
                    usrDal.Update(usrKayit, YETKILITCNO);
                }

                //user details
                var usrDetlsKayit = usrDtlsDal.GetAllQueryable(p => p.LoginUserId == ayarlar.LoginUserId).FirstOrDefault();
                if (usrDetlsKayit == null)
                {
                    usrDetlsKayit = usrDtlsDal.Ekle(ayarlar.UserDetail, MAIL);
                }
                else
                {
                    usrDtlsDal.Update(usrDetlsKayit, YETKILITCNO);
                }
                //profil
                var prflKayit = prfDal.GetAllQueryable(p => p.LoginUserId == ayarlar.LoginUserId).FirstOrDefault();
                if (prflKayit == null)
                {
                    var profil = ObjectMapper.Map(ayarlar.Profile, new Profil());
                    prflKayit = prfDal.Ekle(profil, MAIL);

                }
                else
                {
                    prflKayit.ProfilResimBase64 = ayarlar.Profile.ProfilResimBase64;
                    prflKayit.ProfilResimURl = ayarlar.Profile.ProfilResimURl;
                    prfDal.Update(prflKayit, YETKILITCNO);
                }

                //bildirimler
                var bldrmlrKayit = bildrmlerDal.GetAllQueryable(p => p.LoginUserId == ayarlar.LoginUserId).FirstOrDefault();
                if (bldrmlrKayit == null)
                {
                    bldrmlrKayit = bildrmlerDal.Ekle(ayarlar.Bildirim, MAIL);

                }
                else
                {
                    bildrmlerDal.Update(bldrmlrKayit, YETKILITCNO);
                }

                var ayrKayit = ayarDal.GetAllQueryable(p => p.LoginUserId == ayarlar.LoginUserId).FirstOrDefault();
                if (ayrKayit == null)
                {
                    ayrKayit = ayarDal.Ekle(new Ayarlar()
                    { UserDetailID = usrDetlsKayit.ID, ProfileID = prflKayit.ID, BildirimID = bldrmlrKayit.ID, LoginUserId = ayarlar.LoginUserId }, MAIL);

                }
                else
                {
                    ayrKayit.isDegisiklik = 1;
                    ayarDal.Update(ayrKayit, YETKILITCNO);
                }

                result.Result = ayrKayit;

                result.Message = "Deðiþiklikler kaydedilmiþtir.";
                result.State = MessageResultState.SUCCESS;

                return result;
            }
            catch (Exception)
            {
                result.Message = "Deðiþiklikler Kaydedilmemiþtir.";
                result.State = MessageResultState.ERROR;
            }
             
            return result;
        }

    }
}