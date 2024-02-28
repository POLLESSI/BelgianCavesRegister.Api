using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BelgianCaveRegister_Api.Hubs;
using BelgianCaveRegister_Api.Models;
using BelgianCaveRegister_Api.Tools;
using BelgianCavesRegister.Dal.Interfaces;
using System.Security.Cryptography;
using Microsoft.AspNetCore.SignalR;
using BelgianCavesRegister.Dal.Repository;
using BelgianCaveRegister_Api.Dto.Forms;

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
        private static readonly string[] Descriptions = new[]
        {
            "Fair", "Normal", "UnNatural", "Catastrophic", "Apocalyptic"
        };
        private readonly IWeatherForecastRepository _forecastRepository;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastHub _hub;
        private readonly Dictionary<string, string> _currentWeatherForecast = new Dictionary<string, string>();
        public WeatherForecastController(IWeatherForecastRepository forecastRepository, ILogger<WeatherForecastController> logger, WeatherForecastHub hub, Dictionary<string, string> currentWeatherForecast)
        {
            _forecastRepository = forecastRepository;
            _logger = logger;
            _hub = hub;
            this._currentWeatherForecast = currentWeatherForecast;
        }
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                //TemperatureC = TemperatureC[Random.Shared.Next(-20, 55)],
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Description = Descriptions[Random.Shared.Next(Descriptions.Length)],
                //Humidity = Humidity[Random.Shared.Next(-1, 100)]
                //Precipitation = Precipitation[Random.Shared.Next(0, 1000)]
            })
            .ToArray();
        }
        //[HttpGet]
        //public ActionResult<IEnumerable<WeatherForecast>> GetAll() 
        //{
        //    var activeWeatherForecasts = _forecastRepository.GetAll();
        //    return Ok(activeWeatherForecasts);
        //}
        //public IActionResult GetAll()
        //{
        //    return Ok(_forecastRepository.GetAll());
        //}
        [HttpGet("WeatherForecast_Id")]
        public IActionResult GetById(int weatherForecast_Id)
        {
            return Ok(_forecastRepository.GetById(weatherForecast_Id));
        }
        //[HttpPost]
        //public async Task<IActionResult> Create(WeatherForecastRegisterForm weatherregisterForm)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();
        //    if (_forecastRepository.Create(weatherregisterForm.WeatherForecastToDal()))
        //    {
        //        await _hub.RefreshWeatherForecast();
        //        return Ok(weatherregisterForm);
        //    }
        //    return BadRequest("Registration Error");
        //}
        [HttpPost("update")]
        public async Task<IActionResult> ReceiveWeatherForecastUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentWeatherForecast[item.Key] = item.Value;
            }
            await _hub.Clients.All.SendAsync("ReceiveWeatherUpdate", new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = _currentWeatherForecast["Temperature C : "],
                Summary = _currentWeatherForecast["Summary : "],
                Description = _currentWeatherForecast["Description : "],
                Humidity = _currentWeatherForecast["Humidity : "],
                Precipitation = _currentWeatherForecast["Precipitation : "]
            });
            return Ok(_currentWeatherForecast);

            // OPTIONS: api/WeatherForecast/5
            [HttpOptions("{WeatherForecast_Id}")]
            IActionResult PrefligthRoute(int weatherForecast_Id)
            {
                return NoContent();
            }
            // OPTIONS: api/WeatherForecast
            //[HttpOptions]
            //IActionResult PrefligthRoute()
            //{
            //    return NoContent();
            //}
            //[HttpPut("weatherforecast_Id")]
            //IActionResult PutTodoItem(int weatherForecast_Id)
            //{
            //    if (weatherForecast_Id < 1)
            //    {
            //        return BadRequest();
            //    }
            //}
        }
    }
}
