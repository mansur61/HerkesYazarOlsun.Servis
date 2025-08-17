
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
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : BaseApiController
    {
       
        private IAyarlarDal ayrDal;
        private IYayinAyarlariDal yayrDal;
        public SettingsController(IAyarlarDal ayrDal, IYayinAyarlariDal _yayrDal, IUserAccessor userAccessor, IUnitOfWork unitOfWork, IHttpContextAccessor configuration)
            : base(userAccessor, unitOfWork, configuration)
        {
            this.ayrDal = ayrDal;
            yayrDal = _yayrDal;
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


        [HttpPost]
        [Route("SaveOrUpdateAyarlar")]
        public ServiceResult SaveOrUpdateAyarlar(VM_AYARLAR ayarlar)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS);
           
            IAyarlarDal ayarDal = InstanceFactory.GetInstance<IAyarlarDal>();
            IBildirimlerDal bildrmlerDal = InstanceFactory.GetInstance<IBildirimlerDal>();
            IUsersDetailsDal usrDtlsDal = InstanceFactory.GetInstance<IUsersDetailsDal>();
            IProfilDal prfDal = InstanceFactory.GetInstance<IProfilDal>();
            IUsersDal usrDal = InstanceFactory.GetInstance<IUsersDal>();

            AyarlarValidator validationRules = new AyarlarValidator();
            var sonuc = validationRules.Validate(ayarlar);

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
                using (HerkesYazaOlsunContext ctx = new HerkesYazaOlsunContext())
                {
                    //user 
                    var usrKayit = ctx.Users.Where(p => p.ID == ayarlar.LoginUserId).FirstOrDefault();
                    if (usrKayit == null)
                    {
                        usrKayit = usrDal.Ekle(ayarlar.User, MAIL);

                    }
                    else
                    {
                        ctx.Users.Update(usrKayit);
                        ctx.SaveChanges();
                    }

                    //user details
                    var usrDetlsKayit = ctx.UsersDetails.Where(p => p.LoginUserId == ayarlar.LoginUserId).FirstOrDefault();
                    if (usrDetlsKayit == null)
                    {
                        usrDetlsKayit =  usrDtlsDal.Ekle(ayarlar.UserDetail, MAIL);

                    }
                    else
                    {
                        ctx.UsersDetails.Update(usrDetlsKayit);
                        ctx.SaveChanges();                       
                    }
                    //profil
                    var prflKayit = ctx.Profil.Where(p => p.LoginUserId == ayarlar.LoginUserId).FirstOrDefault();
                    if (prflKayit == null)
                    {
                        prflKayit =  prfDal.Ekle(ayarlar.Profile, MAIL);

                    }
                    else
                    {
                        ctx.Profil.Update(prflKayit);
                        ctx.SaveChanges();
                    }

                    //bildirimler
                    var bldrmlrKayit = ctx.Bildirimler.Where(p => p.LoginUserId == ayarlar.LoginUserId).FirstOrDefault();
                    if (bldrmlrKayit == null)
                    {
                        bldrmlrKayit = bildrmlerDal.Ekle(ayarlar.Bildirim, MAIL);

                    }
                    else
                    {
                        ctx.Bildirimler.Update(bldrmlrKayit);
                        ctx.SaveChanges();
                    }

                    var ayrKayit = ctx.Ayarlar.Where(p => p.LoginUserId == ayarlar.LoginUserId).FirstOrDefault();
                    if (ayrKayit == null)
                    {
                        ayrKayit = ayarDal.Ekle(new Ayarlar() 
                        { UserDetailID = usrDetlsKayit.ID, ProfileID = prflKayit.ID, BildirimID = bldrmlrKayit.ID, LoginUserId = ayarlar.LoginUserId}, MAIL);
                        
                    }
                    else
                    {
                        ayrKayit.isDegisiklik = 1;
                        ctx.Ayarlar.Update(ayrKayit);                       
                        ctx.SaveChanges();
                        //ayrKayit = ctx.Ayarlar.Where(p => p.LoginUserId == ayarlar.LoginUserId).FirstOrDefault();
                    }

                    result.Result = ayrKayit;
                }
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