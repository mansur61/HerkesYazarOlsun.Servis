
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using LinqKit;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilController : ControllerBase
    {
        private IProfilDal prflDal;

        public ProfilController(IProfilDal prflDal)
        {
            this.prflDal = prflDal;
        }

        [HttpGet]
        [Route("GetProfilByLoginId")]
        public Profil? GetProfilByLoginId(long loginId)
        {            
            var sonuc = prflDal.GetAllQueryable(p => p.LoginUserId == loginId).SingleOrDefault();
            return sonuc;
        }

    }
}