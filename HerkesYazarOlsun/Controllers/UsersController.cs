

using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.BLL.Validation;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Servis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {

        private readonly ILogger<UsersController> _logger;
        private IUsersService userService;
        private IFavoriYazarlarService _favoriYazarlarService;
        private IWriterFollowService _writerFollowService;
        private IAccountLoginService _accountLoginService;
        private EmailValidator _emailValidator;
        private UsersValidator _usersValidator;
        private WriterFollowValidator _WriterFollowValidator;
        private WriterStarsValidator _writerStarsValidator;
        private FavoriYazarlarValidator _favYazarValidato; 
        private IWriterStarsService writerStarsService;

        private BooksStarsValidator _booksStarsValidator;
        public UsersController(ILogger<UsersController> logger, IUsersService _userService,
            IUserAccessor userAccessor, IUnitOfWork unitOfWork, IHttpContextAccessor configuration,
            EmailValidator emailValidator, UsersValidator usersValidator, WriterFollowValidator writerFollowValidator, 
            WriterStarsValidator writerStarsValidator, IAccountLoginService accountLoginService, IWriterFollowService writerFollowService, 
            IFavoriYazarlarService favoriYazarlarService, IWriterStarsService writerStarsService, FavoriYazarlarValidator  favYazarValidato)
            : base(userAccessor, unitOfWork, configuration)
        {
            _logger = logger;
            userService = _userService; 
            _emailValidator = emailValidator;
            _usersValidator = usersValidator;
            _WriterFollowValidator = writerFollowValidator;
            _writerStarsValidator = writerStarsValidator;
            _accountLoginService = accountLoginService;
            _writerFollowService = writerFollowService;
            _favoriYazarlarService = favoriYazarlarService;
            this.writerStarsService = writerStarsService;
            _favYazarValidato = favYazarValidato;
        }


        [HttpPost]
        [Route("PostKisiUpdate")]
        public ServiceResult PostKisiUpdate(VM_USERS kisi)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS, message: ""); 
            var user = ObjectMapper.Map(kisi, new Users());

            var sonuc = _emailValidator.Validate(user);
            if (!sonuc!.IsValid)
            {
                result.State = MessageResultState.ERROR;
                foreach (var item in sonuc.Errors)
                {
                    result.Message += item.ErrorMessage + ",";
                }

                return result;
            }

            try
            {
                var kayit = userService.GetMail( kisi.EMAIL);
                if (kayit != null)
                {
                    kayit.isEmail = 1;
                    kayit = userService.Guncelle(kayit,YETKILITCNO);
                }
                else
                {
                    result.State = MessageResultState.WARNING;
                    result.Message = "Bu þekilde mail adresi yok";
                    return result;
                }

            }
            catch (Exception ex)
            {
                result.State = MessageResultState.ERROR;
                result.Message = "Güncelleme Baþarýsýz";
                return result;
            }
            return result;
        }

        [HttpPost]
        [Route("PostKisiSave")]
        public ServiceResult PostKisiSave(VM_USERS kisi)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS, message: ""); 
            var user = ObjectMapper.Map(kisi, new Users());


            var sonuc = _usersValidator.Validate(user);
            if (!sonuc!.IsValid)
            {
                result.State = MessageResultState.ERROR;
                foreach (var item in sonuc.Errors)
                {
                    result.Message += item.ErrorMessage + ",";// + Environment.NewLine;
                }

                //result.Message = sonuc.Errors[0].ErrorMessage;
                return result;
            }

            try
            {
                var kayit = userService.GetMail(kisi.EMAIL);
                if (kayit != null)
                {
                    result.State = MessageResultState.WARNING;
                    result.Message = "Böyle bir kullanýcý var.";
                    return result;
                }
                else
                {
                    user = userService.Ekle(user, kisi.EMAIL ?? "");
                    result.Message = "Kayýt Alýndý";
                }

            }
            catch (Exception ex)
            {
                result.State = MessageResultState.ERROR;
                result.Message = "Kayýt Baþarýsýz";
                return result;
            }
            return result;
        }

        [HttpGet]
        [Route("GetMaxStarWriterById")]
        public VM_Stars GetMaxStarWriterById(long id)
        {
            return userService.GetMaxStarWriterById(id);
        }


        [HttpGet]
        [Route("GetKisiById")]
        public Users? GetKisiById(long id)
        {
            var getKisi = userService.Get(id);
            return getKisi;
        }

        [HttpGet]
        [Route("GetKisiByUsername")]
        public Users? GetKisiByUsername(string username)
        { 
            var getKisi = userService.GetUserrName(username);
            return getKisi;
        }

        [HttpGet]
        [Route("GetKisiByMail")]
        public ServiceResult<Users> GetKisiByMail(string mail)
        {
            ServiceResult<Users> result = new ServiceResult<Users>(state: MessageResultState.SUCCESS);

            var getKisi = userService.GetMail(mail);

            if (getKisi != null)
            {
                var sonuc = _emailValidator.Validate(getKisi);
                if (!sonuc!.IsValid)
                {
                    result.State = MessageResultState.ERROR;
                    foreach (var item in sonuc.Errors)
                    {
                        result.Message += item.ErrorMessage + ",";
                    }

                    return result;
                }

            }
            else
            {

                result.Message = "Mail adresi yok,kayýt yaptýrýnýz.";
                result.State = MessageResultState.ERROR;

            }

            result.Result = getKisi!;
            return result;

        }

        private VM_Stars CalculateMaxStarFromMemory(Users user)
        {
            if (user.WriterStarsYazarList == null || !user.WriterStarsYazarList.Any())
                return null;

            var vM_WriterStars = new VM_Stars();

            var starsGrouped = user.WriterStarsYazarList
                .GroupBy(ws => ws.StarPuani)
                .Select(g => new { Star = g.Key, Count = g.Count() })
                .ToList();

            vM_WriterStars.BirStarToplam = starsGrouped.FirstOrDefault(s => s.Star == 1)?.Count ?? 0;
            vM_WriterStars.IkiStarToplam = starsGrouped.FirstOrDefault(s => s.Star == 2)?.Count ?? 0;
            vM_WriterStars.UcStarToplam = starsGrouped.FirstOrDefault(s => s.Star == 3)?.Count ?? 0;
            vM_WriterStars.DortStarToplam = starsGrouped.FirstOrDefault(s => s.Star == 4)?.Count ?? 0;
            vM_WriterStars.BesStarToplam = starsGrouped.FirstOrDefault(s => s.Star == 5)?.Count ?? 0;

            var maxStar = starsGrouped.OrderByDescending(s => s.Count).FirstOrDefault();
            if (maxStar != null)
            {
                vM_WriterStars.HangiStar = $"yildiz{maxStar.Star}";
                vM_WriterStars.EnFazlaSitar = maxStar.Count;
            }

            return vM_WriterStars;
        }


        
        [HttpPost]
        [Route("GetKisiler")]
        public List<VM_USERS> GetKisiler(VM_ARAMA_INPUT arama)
        { 

            var getKisiler = userService.GetKullanicilar();
            if (!string.IsNullOrEmpty(arama.YAZAR_ADI))
            {
                getKisiler = getKisiler.Where(p => p.NAME!.Contains(arama.YAZAR_ADI!)).ToList();
            }

            if (arama.yazarIId.HasValue)
            {
                getKisiler = getKisiler.Where(p => p.ID == arama.yazarIId).ToList();
            }

            if (arama.FavoriYazarlar.HasValue)
            {
                getKisiler = getKisiler.Where(p => p.FavoriYazarlarList.Any()).ToList();
            }
            

            var vmUserList = getKisiler
             .Select(u =>
             {
                 var vmUser = VM_USERS.MapToVM(u);
                 vmUser.Stars = CalculateMaxStarFromMemory(u);   // Zamanla inner join yapýsýna geç. pl/sql de
                 return vmUser;
             })
             .ToList();

            return vmUserList;
        }

        [HttpPost]
        [Route("PostFavoriSaveWriter")]
        public ServiceResult PostFavoriSaveWriter(VM_FAVORI_YAZARLAR fav)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS);
            try
            {
                var favYazar = ObjectMapper.Map(fav, new FavoriYazarlar());
                var sonuc = _favYazarValidato.Validate(favYazar);

                if (!sonuc!.IsValid)
                {
                    foreach (var item in sonuc.Errors)
                    {
                        result.Message += item.ErrorMessage + ",";
                    }

                    result.State = MessageResultState.ERROR;
                    return result;
                }

                
                favYazar = _favoriYazarlarService.Ekle(favYazar, MAIL);
                result.Result = favYazar;
                result.Message = "Yazar Favorilere Eklendi";
                
            }
            catch (Exception)
            {
                result.Result = null;
                result.State = MessageResultState.ERROR;
                result.Message = "Yazar Favorilere Eklenemeddi";
            }
            return result;
        }

        [HttpGet]
        [Route("GetWriterFollowById")]
        public VM_WriterFollow GetWriterFollowById(long yazar_id)
        { 
            var follow = _writerFollowService.Get(yazar_id);
            var fllwYazar = ObjectMapper.Map(follow, new VM_WriterFollow());

            return fllwYazar;
        }

        [HttpGet]
        [Route("GetUsersByLoginId")]
        public Users? GetUserByLoginId(long loginId)
        {
            var sonuc = userService.Get(loginId);
            return sonuc;
        }

        [HttpPost]
        [Route("SaveOrUpdateAccountLogin")]
        public ServiceResult SaveOrUpdateAccountLogin(VM_LOGIN vmLogni)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS);             

            var bak = MAIL;
            var accountLogin = ObjectMapper.Map(vmLogni, new AccountLogin());
            try
            {

                var mevcutKayit = _accountLoginService.Get(vmLogni.LoginUserId);
                if (mevcutKayit == null)
                {
                    accountLogin.OLUSTURAN_EMAIL = vmLogni.email;
                    accountLogin = _accountLoginService.Ekle(accountLogin, MAIL);
                }
                else
                {
                    mevcutKayit.OLUSTURAN_EMAIL = vmLogni.email;
                    mevcutKayit.benihatirla = vmLogni.benihatirla;
                    mevcutKayit.RememberLogin = vmLogni.RememberLogin;
                    mevcutKayit.LoginUserId = vmLogni.LoginUserId;
                    mevcutKayit.email = vmLogni.email;
                    _accountLoginService.Guncelle(mevcutKayit, YETKILITCNO);
                }

                result.State = MessageResultState.SUCCESS;
                return result;
            }
            catch (Exception)
            {
                result.Message = "";
                result.State = MessageResultState.ERROR;
            }

            result.Result = accountLogin;
            return result;
        }

        [HttpPost]
        [Route("PostWriterStars")]
        public ServiceResult<WriterStars> PostWriterStars(WriterStars star)
        {
            ServiceResult<WriterStars> result = new ServiceResult<WriterStars>(state: MessageResultState.SUCCESS);

             
            var sonuc = _writerStarsValidator.Validate(star);

            if (!sonuc!.IsValid)
            {
                //result.State = MessageResultState.ERROR;
                foreach (var item in sonuc.Errors)
                {
                    result.Message += item.ErrorMessage + ",";
                }

                result.State = MessageResultState.ERROR;
                return result;
            }

            try
            {

                var mevcutKayit = writerStarsService.Get( star.LoginUserId ?? 0 ,star.YazarId ?? 0);
                if (mevcutKayit == null)
                {
                    star = writerStarsService.Ekle(star,MAIL);
                }
                else
                {
                    mevcutKayit!.StarPuani = star.StarPuani;
                    writerStarsService.Guncelle(mevcutKayit,YETKILITCNO);
                }


                result.State = MessageResultState.SUCCESS;
                return result;
            }
            catch (Exception)
            {
                result.Message = "";
                result.State = MessageResultState.ERROR;
            }

            result.Result = star;
            return result;
        }

        [HttpPost]
        [Route("PostWriterFollow")]
        public ServiceResult<WriterFollow> PostWriterFollow(WriterFollow follow)
        {
            ServiceResult<WriterFollow> result = new ServiceResult<WriterFollow>(state: MessageResultState.SUCCESS);
            IWriterFollowDal followDal = InstanceFactory.GetInstance<IWriterFollowDal>().Service;
            var sonuc = _WriterFollowValidator.Validate(follow);

            if (!sonuc!.IsValid)
            {
                //result.State = MessageResultState.ERROR;
                foreach (var item in sonuc.Errors)
                {
                    result.Message += item.ErrorMessage + ",";
                }

                result.State = MessageResultState.ERROR;
                return result;
            }

            try
            {


                var mevcutKayit = followDal.Get(p => p.LoginUserId == follow.LoginUserId && p.YazarId == follow.YazarId);
                if (mevcutKayit == null)
                {
                    follow = followDal.Add(follow);
                }
                else
                {
                    if (follow.isFollow == 1)
                    {
                        mevcutKayit.isFollow = 1;
                        result.Message = "Takipten Ediliyor.";
                    }
                    else
                    {
                        mevcutKayit.isFollow = 0;
                        result.Message = "Takipten Çýkýldý.";
                    }

                    followDal.Update(mevcutKayit);
                }


            }
            catch (Exception)
            {
                result.Message = "";
                result.State = MessageResultState.ERROR;
            }



            result.Result = follow;
            return result;
        }

    }
}