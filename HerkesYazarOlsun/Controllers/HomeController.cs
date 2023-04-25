using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Servis.Models;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<HomeController> _logger;
        private readonly HerkesyazarolsunContext _context;

        public HomeController(ILogger<HomeController> logger, HerkesyazarolsunContext _context)
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
            return Ok(this._context.KISILER.ToList());
        }

    }
}