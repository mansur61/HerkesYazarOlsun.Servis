using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.BLL.Validation;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using HerkesYazarOlsun.Servis.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Servis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : BaseApiController
    {

        private IAyarlarService ayrSrv;
        private IUsersService usersSrv;
        private IYayinAyarlariService yayrSrv;
        private IUsersDetailsService UsersDetailsService;
        private IBildirimlerService bildirimlerService;
        private IProfilService profilSrv;
        private readonly ILogger<SettingsController> _logger;
        private IFtpService _ftpService;
        private AyarlarValidator _ayarlarValidator;
        public SettingsController(IAyarlarService ayrSrv, IYayinAyarlariService yayrSrv, IFtpService ftpService, IProfilService profilSrv,
            IUserAccessor userAccessor, IUnitOfWork unitOfWork, IHttpContextAccessor configuration, ILogger<SettingsController> logger,
            AyarlarValidator ayarlarValidator, IUsersService usersSrv, IUsersDetailsService usersDetailsService, IBildirimlerService bildirimlerService)
            : base(userAccessor, unitOfWork, configuration)
        {
            this.ayrSrv = ayrSrv;
            this.yayrSrv = yayrSrv;
            _logger = logger;
            _ftpService = ftpService;
            _ayarlarValidator = ayarlarValidator;
            this.profilSrv = profilSrv;
            this.usersSrv = usersSrv;
            UsersDetailsService = usersDetailsService;
            this.bildirimlerService = bildirimlerService;
        }


        [HttpGet]
        [Route("GetAyarlarByLoginId")]
        public Ayarlar? GetProfilByLoginId(long loginId)
        {
            var sonuc = ayrSrv.GetProfilByLoginId(loginId);
            return sonuc;
        }

        [HttpGet]
        [Route("GetYyainAyarlari")]
        public YayinAyarlari? GetYayinAyarlari()
        {
            var sonuc = yayrSrv.GetYayinAyarlari();
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
                var usrKayit = usersSrv.Get(ayarlar.LoginUserId);
                if (usrKayit == null)
                {
                    usrKayit = usersSrv.Ekle(ayarlar.User, MAIL);

                }
                else
                {
                    usersSrv.Guncelle(usrKayit, YETKILITCNO);
                }

                //user details
                var usrDetlsKayit = UsersDetailsService.Get(ayarlar.LoginUserId);
                if (usrDetlsKayit == null)
                {
                    usrDetlsKayit = UsersDetailsService.Ekle(ayarlar.UserDetail, MAIL);
                }
                else
                {
                    UsersDetailsService.Guncelle(usrDetlsKayit, YETKILITCNO);
                }
                //profil
                var prflKayit = profilSrv.Get(ayarlar.LoginUserId);
                if (prflKayit == null)
                {
                    var profil = ObjectMapper.Map(ayarlar.Profile, new Profil());
                    prflKayit = profilSrv.Ekle(profil, MAIL);

                }
                else
                {
                    prflKayit.ProfilResimBase64 = ayarlar.Profile.ProfilResimBase64;
                    prflKayit.ProfilResimURl = ayarlar.Profile.ProfilResimURl;
                    profilSrv.Guncelle(prflKayit, YETKILITCNO);
                }

                //bildirimler
                var bldrmlrKayit = bildirimlerService.Get(ayarlar.LoginUserId);
                if (bldrmlrKayit == null)
                {
                    bldrmlrKayit = bildirimlerService.Ekle(ayarlar.Bildirim, MAIL);

                }
                else
                {
                    bildirimlerService.Guncelle(bldrmlrKayit, YETKILITCNO);
                }

                var ayrKayit = ayrSrv.GetAyar(ayarlar.LoginUserId);
                if (ayrKayit == null)
                {
                    ayrKayit = ayrSrv.Ekle(new Ayarlar()
                    { UserDetailID = usrDetlsKayit.ID, ProfileID = prflKayit.ID, BildirimID = bldrmlrKayit.ID, LoginUserId = ayarlar.LoginUserId }, MAIL);

                }
                else
                {
                    ayrKayit.isDegisiklik = 1;
                    ayrSrv.Guncelle(ayrKayit, YETKILITCNO);
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