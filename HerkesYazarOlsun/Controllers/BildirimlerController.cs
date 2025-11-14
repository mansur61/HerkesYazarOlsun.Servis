using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Servis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BildirimlerController : ControllerBase
    {
        private IBildirimlerDal bildrmlerDal;

        public BildirimlerController(IBildirimlerDal bildrmlerDal)
        {
            this.bildrmlerDal = bildrmlerDal;
        }

        [HttpGet]
        [Route("GetBildirimlerByLoginId")]
        public Bildirimler? GetBildirimlerByLoginId(long loginId)
        {            
            var sonuc = bildrmlerDal.GetAllQueryableNoTracking(p => p.LoginUserId == loginId).SingleOrDefault();
            return sonuc;
        }

    }
}