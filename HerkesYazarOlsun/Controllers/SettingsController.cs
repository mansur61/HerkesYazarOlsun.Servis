using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.BLL.Validation;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
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
        private IUnitOfWork _unitOfWork;
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

            _unitOfWork = unitOfWork;
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
        public List<YayinAyarlari>? GetYayinAyarlari()
        {
            var sonuc = yayrSrv.GetYayinAyarlari();
            return sonuc;
        }

        [HttpGet]
        [Route("GetYayinAyarlariByBookId")]
        public YayinAyarlari? GetYayinAyarlariByBookId(long id)
        {
            var sonuc = yayrSrv.GetYayinAyarlariByBookId(id);
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
            ServiceResult result = new ServiceResult(state:MessageResultState.SUCCESS);

            if (ayarlar.dosyalar != null && ayarlar.dosyalar.Count > 0)
                ayarlar = await ModelIlgiliDosyalariDoldur(ayarlar);

            var validate = _ayarlarValidator.Validate(ayarlar);
            if (!validate.IsValid)
            {
                result.Message = string.Join(",", validate.Errors.Select(x => x.ErrorMessage));
                result.State = MessageResultState.WARNING;
                return result;
            }

            try
            {
                _unitOfWork.OpenTransaction();

                // -----------------------------
                // 1) USERS
                // -----------------------------
                var usrKayit = usersSrv.Get(ayarlar.LoginUserId);
                if (usrKayit == null)
                {
                    usrKayit = _unitOfWork.GetWriteRepositoryWithNewBaseEntity(ayarlar.User);
                }
                else
                {
                    var guncelData = ObjectMapper.Map(ayarlar.User, usrKayit);
                    _unitOfWork.GetWriteUpdateRepositoryWithNewBaseEntity(guncelData);
                }

                // -----------------------------
                // 2) USER DETAILS
                // -----------------------------
                var usrDetay = UsersDetailsService.Get(ayarlar.LoginUserId);
                if (usrDetay == null)
                {
                    usrDetay = _unitOfWork.GetWriteRepositoryWithNewBaseEntity(ayarlar.UserDetail);
                }
                else
                {
                    var guncelData = ObjectMapper.Map(ayarlar.UserDetail, usrDetay);
                    _unitOfWork.GetWriteUpdateRepositoryWithNewBaseEntity(guncelData);
                }

                // -----------------------------
                // 3) PROFIL
                // -----------------------------
                var profil = profilSrv.Get(ayarlar.LoginUserId);
                if (profil == null)
                {
                    var prf = ObjectMapper.Map(ayarlar.Profile, new Profil());
                    prf.UserId = ayarlar.LoginUserId;

                    profil = _unitOfWork.GetWriteRepositoryWithNewBaseEntity(prf);
                }
                else
                { 
                    profil.ProfilResimBase64 = ayarlar.Profile.ProfilResimBase64 ?? profil.ProfilResimBase64;
                    profil.ProfilResimURl = ayarlar.Profile.ProfilResimURl ?? profil.ProfilResimURl;
                    profil.ProfilArkaplanResmi = ayarlar.Profile.ProfilArkaplanResmi ?? profil.ProfilArkaplanResmi;
                    profil.ProfilArkaplanRenkKodu = ayarlar.Profile.ProfilArkaplanRenkKodu ?? profil.ProfilArkaplanRenkKodu;
                    
                    _unitOfWork.GetWriteUpdateRepositoryWithNewBaseEntity(profil);
                }

                // -----------------------------
                // 4) BILDIRIMLER
                // -----------------------------
                var bildirim = bildirimlerService.Get(ayarlar.LoginUserId);
                if (bildirim == null)
                {
                    bildirim = _unitOfWork.GetWriteRepositoryWithNewBaseEntity(ayarlar.Bildirim);
                }
                else
                {
                    var guncelData = ObjectMapper.Map(ayarlar.Bildirim, bildirim);
                    _unitOfWork.GetWriteUpdateRepositoryWithNewBaseEntity(guncelData);
                }

                // -----------------------------
                // 5) AYARLAR TABLOSU
                // -----------------------------
                var ayarKayit = ayrSrv.GetAyar(ayarlar.LoginUserId);

                if (ayarKayit == null)
                {
                    var yeniAyar = new Ayarlar
                    {
                        UserDetailID = usrDetay.ID,
                        ProfileID = profil.ID,
                        BildirimID = bildirim.ID,
                        LoginUserId = ayarlar.LoginUserId
                    };

                    ayarKayit = _unitOfWork.GetWriteRepositoryWithNewBaseEntity(yeniAyar);
                }
                else
                {
                    ayarKayit.isDegisiklik = 1;
                    _unitOfWork.GetWriteUpdateRepositoryWithNewBaseEntity(ayarKayit);
                }

                result.Result = ayarKayit;
                result.Message = "Deðiþiklikler kaydedilmiþtir.";
                result.State = MessageResultState.SUCCESS;

                _unitOfWork.CommitTransaction();
                _unitOfWork.Save();

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

    }
}