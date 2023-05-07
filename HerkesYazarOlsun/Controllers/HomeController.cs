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
    public class HomeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<HomeController> _logger;
        private readonly HerkesYazaOlsunContext _context;
       

        public HomeController(ILogger<HomeController> logger, HerkesYazaOlsunContext _context)
        {
            _logger = logger;
            this._context = _context;
            


        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<HomeModel> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new HomeModel
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<HomeModel> Index()
        {
            return Enumerable.Range(1, 5).Select(index => new HomeModel
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("Getir")]
        public IActionResult Getir()
        {
            IKisilerService kisilerBll = InstanceFactory.GetInstance<IKisilerService>();
            var getKisiler = kisilerBll.GetKullanicilar();
            //this._context.KISILER.ToList()
            return Ok(getKisiler);
        }

    }
}