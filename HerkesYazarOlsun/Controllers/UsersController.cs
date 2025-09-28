

using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.BLL.Validation;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using HerkesYazarOlsun.Servis.Controllers;
using LinqKit;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {

        private readonly ILogger<UsersController> _logger;
        private IUsersService userService;
        private IUsersDal kisilerDal;
        private EmailValidator _emailValidator;
        private UsersValidator _usersValidator;
        private WriterFollowValidator _WriterFollowValidator;
        private WriterStarsValidator _writerStarsValidator;
        public UsersController(ILogger<UsersController> logger, IUsersService _userService,
            IUsersDal kisilerDal, IUserAccessor userAccessor, IUnitOfWork unitOfWork, IHttpContextAccessor configuration,
            EmailValidator emailValidator, UsersValidator usersValidator, WriterFollowValidator writerFollowValidator, WriterStarsValidator writerStarsValidator)
            : base(userAccessor, unitOfWork, configuration)
        {
            _logger = logger;
            userService = _userService;
            this.kisilerDal = kisilerDal;
            _emailValidator = emailValidator;
            _usersValidator = usersValidator;
            _WriterFollowValidator = writerFollowValidator;
            _writerStarsValidator = writerStarsValidator;
        }


        [HttpPost]
        [Route("PostKisiUpdate")]
        public ServiceResult PostKisiUpdate(VM_USERS kisi)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS, message: "");
            IUsersDal kisilerDal = InstanceFactory.GetInstance<IUsersDal>().Service;
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
                var kayit = kisilerDal.GetAllQueryable(p => p.EMAIL == kisi.EMAIL).SingleOrDefault();
                if (kayit != null)
                {
                    kayit.isEmail = 1;
                    kayit = kisilerDal.Guncelle(kayit, MAIL ?? kisi.EMAIL ?? "");
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
            IUsersDal kisilerDal = InstanceFactory.GetInstance<IUsersDal>().Service;
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
                var kayit = kisilerDal.GetAllQueryable(p => p.EMAIL == kisi.EMAIL).SingleOrDefault();
                if (kayit != null)
                {
                    result.State = MessageResultState.WARNING;
                    result.Message = "Böyle bir kullanýcý var.";
                    return result;
                }
                else
                {
                    user = kisilerDal.Ekle(user, kisi.EMAIL ?? "");
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
            IUsersDal kisilerDal = InstanceFactory.GetInstance<IUsersDal>().Service;
            var getKisi = kisilerDal.GetAllQueryable(p => p.ID == id).SingleOrDefault();
            return getKisi;
        }

        [HttpGet]
        [Route("GetKisiByUsername")]
        public Users? GetKisiByUsername(string username)
        {
            IUsersDal kisilerDal = InstanceFactory.GetInstance<IUsersDal>().Service;
            var getKisi = kisilerDal.GetAllQueryable(p => p.SURNAME == username).SingleOrDefault();
            return getKisi;
        }

        [HttpGet]
        [Route("GetKisiByMail")]
        public ServiceResult<Users> GetKisiByMail(string mail)
        {
            ServiceResult<Users> result = new ServiceResult<Users>(state: MessageResultState.SUCCESS);

            IUsersDal kisilerDal = InstanceFactory.GetInstance<IUsersDal>().Service;
            var getKisi = kisilerDal.GetAllQueryable(p => p.EMAIL == mail).SingleOrDefault();

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

        //Zamanla inner join yapýsýna geç. pl/sql de
        [HttpPost]
        [Route("GetKisiler")]
        public List<VM_USERS> GetKisiler(VM_ARAMA_INPUT arama)
        {
            IUsersService kisilerBll = InstanceFactory.GetInstance<IUsersService>().Service;

            var getKisiler = kisilerBll.GetKullanicilar();
            if (!string.IsNullOrEmpty(arama.YAZAR_ADI))
            {
                getKisiler = getKisiler.Where(p => p.NAME!.Contains(arama.YAZAR_ADI!)).ToList();
            }

            var vmUserList = getKisiler
                     .Select(u =>
                     {
                         var vmUser = VM_USERS.MapToVM(u);
                         vmUser.Stars = GetMaxStarWriterById(u.ID);
                         return vmUser;
                     })
                 .ToList(); 

            return vmUserList;
        }

        [HttpPost]
        [Route("PostFavoriSaveWriter")]
        public FAVORI_YAZARLAR PostFavoriSaveWriter(VM_FAVORI_YAZARLAR fav)
        {
            IFavYazarDal yazarDal = InstanceFactory.GetInstance<IFavYazarDal>().Service;
            var favYazar = ObjectMapper.Map(fav, new FAVORI_YAZARLAR());
            favYazar = yazarDal.Ekle(favYazar, MAIL);
            return favYazar;
        }

        [HttpGet]
        [Route("GetWriterFollowById")]
        public VM_WriterFollow GetWriterFollowById(long yazar_id)
        {
            IWriterFollowDal yazarDal = InstanceFactory.GetInstance<IWriterFollowDal>().Service;
            var follow = yazarDal.Get(p => p.YazarId == yazar_id);
            var fllwYazar = ObjectMapper.Map(follow, new VM_WriterFollow());

            return fllwYazar;
        }

        [HttpGet]
        [Route("GetUsersByLoginId")]
        public Users? GetUserByLoginId(long loginId)
        {
            var sonuc = kisilerDal.GetAllQueryable(p => p.ID == loginId).SingleOrDefault();
            return sonuc;
        }

        [HttpPost]
        [Route("SaveOrUpdateAccountLogin")]
        public ServiceResult SaveOrUpdateAccountLogin(VM_LOGIN vmLogni)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS);

            IAccountLoginDal accLoginDal = InstanceFactory.GetInstance<IAccountLoginDal>().Service;

            var bak = MAIL;
            var accountLogin = ObjectMapper.Map(vmLogni, new AccountLogin());
            try
            {
                using (HerkesYazaOlsunContext ctx = new HerkesYazaOlsunContext())
                {
                    var mevcutKayit = ctx.AccountLogin.Where(p => p.LoginUserId == vmLogni.LoginUserId).FirstOrDefault();
                    if (mevcutKayit == null)
                    {
                        accountLogin.OLUSTURAN_EMAIL = vmLogni.email;
                        accountLogin = accLoginDal.Ekle(accountLogin, MAIL);
                    }
                    else
                    {
                        mevcutKayit.OLUSTURAN_EMAIL = vmLogni.email;
                        mevcutKayit.benihatirla = vmLogni.benihatirla;
                        mevcutKayit.RememberLogin = vmLogni.RememberLogin;
                        mevcutKayit.LoginUserId = vmLogni.LoginUserId;
                        mevcutKayit.email = vmLogni.email;
                        ctx.AccountLogin.Update(mevcutKayit);
                        ctx.SaveChanges();
                    }

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

            IWriterStarsDal yazarDal = InstanceFactory.GetInstance<IWriterStarsDal>().Service;
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
                using (HerkesYazaOlsunContext ctx = new HerkesYazaOlsunContext())
                {
                    var mevcutKayit = ctx.WriterStars.Where(p => p.LoginUserId == star.LoginUserId && p.YazarId == star.YazarId).FirstOrDefault();
                    if (mevcutKayit == null)
                    {
                        star = yazarDal.Add(star);
                    }
                    else
                    {
                        mevcutKayit!.StarPuani = star.StarPuani;
                        ctx.WriterStars.Update(mevcutKayit);
                        ctx.SaveChanges();
                    }

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
            IWriterFollowDal yazarDal = InstanceFactory.GetInstance<IWriterFollowDal>().Service;
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

                using (HerkesYazaOlsunContext ctx = new HerkesYazaOlsunContext())
                {
                    var mevcutKayit = ctx.WriterFollow.Where(p => p.LoginUserId == follow.LoginUserId && p.YazarId == follow.YazarId).FirstOrDefault();
                    if (mevcutKayit == null)
                    {
                        follow = yazarDal.Add(follow);
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

                        //yazarDal.Update(follow);
                        ctx.WriterFollow.Update(mevcutKayit);
                        ctx.SaveChanges();
                    }

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