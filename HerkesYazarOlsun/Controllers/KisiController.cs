using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Concrete;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Concrete.EntityFramework;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Servis.Models;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KisiController : ControllerBase
    {
      
        private readonly ILogger<KisiController> _logger;

        public KisiController(ILogger<KisiController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("GetKisiByTC")]
        public IActionResult GetKisiByTC(long id)
        {
            IKisilerService kisilerBll = InstanceFactory.GetInstance<IKisilerService>();
            var getKisiler = kisilerBll.GetKullanicilar();
             var getKisi = getKisiler.Where(p=>p.ID == id).FirstOrDefault();
            return Ok(getKisi);
        }

    }
}