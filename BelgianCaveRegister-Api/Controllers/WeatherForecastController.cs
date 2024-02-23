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
        private readonly IWeatherForecastRepository _forecastsRepository;
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastHub _hub;
        private readonly Dictionary<string, string> currentWeatherForecast = new Dictionary<string, string>();

        public WeatherForecastController(IWeatherForecastRepository forecastRepository,ILogger<WeatherForecastController> logger, WeatherForecastHub hub)
        {
            _forecastsRepository = forecastRepository;
            _logger = logger;
            _hub = hub;
        }
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get() 
        { 
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                //TemperatureC = TemperatureC[Random.Shared.Next(-20, 55)],
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                //Description = Description[Random.Shared.Next(Descriptions.Length)],
                //Humidity = Humidity[Random.Shared.Next(-1, 100)],
                //Precipitation = Precipitaton[Random.Shared.Next(0, 1000)]
            })
            .ToArray();
        }
        //[HttpGet]
        //public ActionResult<IEnumerable<WeatherForecast>> GetAll() 
        //{
        //    var activeWeatherForecasts = _forecastsRepository.GetAll();
        //    return Ok(activeWeatherForecasts);
        //}
        //public IActionResult GetAll()
        //{
        //    return Ok(_forecastsRepository.GetAll());
        //}
        //[HttpGet]
        //public IActionResult GetById(int weatherForecast_Id)
        //{
        //    return Ok(_forecastsRepository.GetById(weatherForecast_Id));
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(WeatherForecastRegisterForm weatherregisterForm)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();
        //    if (_forecastsRepository.Create(weatherregisterForm.WeatherForecastToDal()))
        //    {
        //        await _hub.RefreshWeaterForecast();
        //        return Ok(weatherregisterForm);
        //    }
        //    return BadRequest("Registration Error");
        //}
        [HttpPost("update")]
        public async Task<IActionResult> ReceiveWeatherForecastUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                currentWeatherForecast[item.Key] = item.Value;
            }
            // Send weather update to all clients connected via hub
            await _hub.Clients.All.SendAsync("ReceiveWeatherUpdate", new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = currentWeatherForecast["TemperatureC : "],
                Summary = currentWeatherForecast["Summary : "],
                Description = currentWeatherForecast["Description : "], 
                Humidity = currentWeatherForecast["Humidity : "],
                Precipitation = currentWeatherForecast["Precipitation : "]
            });

            return Ok(currentWeatherForecast);
        }

        //// OPTIONS: api/WeatherForecast/5
        //[HttpOptions("{id}")]
        //public IActionResult PreflightRoute(int weatherForecast_Id)
        //{
        //    return NoContent();
        //}
        ////OPTIONS: api/WeatherForecast
        //[HttpOptions]
        //public IActionResult PreflightRoute()
        //{
        //    return NoContent();
        //}
        //[HttpPut("{weatherforecast_id}")]
        ////public IActionResult PutTodoItem(int weatherForecast_id) 
        ////{
        ////    if (weatherForecast_id < 1)
        ////    {
        ////        return BadRequest();
        ////    }
        ////}
    }
}
