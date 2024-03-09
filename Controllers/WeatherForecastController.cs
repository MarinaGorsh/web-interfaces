using Microsoft.AspNetCore.Mvc;

namespace _6lr.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("byday", Name = "GetWeatherForecastbyDay")]
        public WeatherForecast GetbyDay()
        {
            return new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-10, 20),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }
        [HttpPost(Name = "PostWeatherForecast")]
        public IActionResult Post([FromBody] WeatherForecast request)
        {
            var forecast = new WeatherForecast
            {
                Date = request.Date,
                TemperatureC = request.TemperatureC,
                Summary = request.Summary
            };

            return Ok(forecast);
        }
    }
}