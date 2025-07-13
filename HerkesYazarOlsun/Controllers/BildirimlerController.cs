using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
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
            var sonuc = bildrmlerDal.GetAllQueryable(p => p.LoginUserId == loginId).SingleOrDefault();
            return sonuc;
        }

    }
}