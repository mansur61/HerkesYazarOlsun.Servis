using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Servis.Models;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly HerkesYazaOlsunContext _context;
       

        public HomeController(ILogger<HomeController> logger, HerkesYazaOlsunContext _context)
        {
            this._context = _context;

        }

        [HttpGet]
        [Route("Getir")]
        public IActionResult Getir()
        {
            IUsersService kisilerBll = InstanceFactory.GetInstance<IUsersService>().Service;
            var getKisiler = kisilerBll.GetKullanicilar();  
            return Ok(getKisiler);
        }

    }
}