using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zabita.DataAccessLayer.Concrete.EntityFramework;
using Zabita.Entities.Concrete;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Amirlik> Get()
        {
            ZabitaDatabaseContext databaseContext = new ZabitaDatabaseContext();

            var result = from i in databaseContext.Set<Amirlik>()
                         .Select(index => new { index.AmirlikID, index.AmirlikIsım, index.AmirlikSeriNo, index.YerleskeBakimOnarim })
                         select new Amirlik { AmirlikID = i.AmirlikID, AmirlikIsım = i.AmirlikIsım, AmirlikSeriNo = i.AmirlikSeriNo, YerleskeBakimOnarim = i.YerleskeBakimOnarim };
            return result.ToArray();

            /*var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();*/
        }
    }
}