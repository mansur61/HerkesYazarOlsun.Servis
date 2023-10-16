using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BusinessLayer.Factory;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
      
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("GetKisiByTC")]
        public IActionResult GetKisiByTC(long id)
        {
            IUsersBll kisilerBll = InstanceFactory.GetInstance<IUsersBll>(); 
            var getKisiler = kisilerBll.GetKullanicilar();
             var getKisi = getKisiler.Where(p=>p.ID == id).FirstOrDefault();
            return Ok(getKisi);
        }

    }
}