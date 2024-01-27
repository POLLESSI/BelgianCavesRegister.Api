using Microsoft.AspNetCore.Mvc;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freesing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Dictionary<string, string> currentWeatherForecast = new Dictionary<string, string>();

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
        [HttpPost("update")]
        public IActionResult ReceiveWeatherForecastUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                currentWeatherForecast[item.Key] = item.Value;
            }
            return Ok(currentWeatherForecast);
        }
    }
}
