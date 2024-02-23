using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using BelgianCavesRegister.Dal.Interfaces;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Http.Connections.Client;
using System.Data.Entity.Infrastructure;
using BelgianCavesRegister.Bll.Interfaces;

namespace BelgianCavesRegister.Bll.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastService _weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastService weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public bool Create(WeatherForecast weatherForecast)
        {
            try
            {
                return _weatherForecastRepository.Create(weatherForecast);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating weather forecast: {ex.ToString}");
            }
            return false;
        }

        public void CreateWeatherForecast(WeatherForecast weatherForecast)
        {
            try
            {
                _weatherForecastRepository.CreateWeatherForecast(weatherForecast);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Create Weather Forecast : {ex.ToString}");
            }
        }

        public WeatherForecast? Delete(int weatherForecast_Id)
        {
            try
            {
                return _weatherForecastRepository.Delete(weatherForecast_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting weather forecast : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<WeatherForecast> GetAll()
        {
            return _weatherForecastRepository.GetAll();
        }

        public WeatherForecast? GetById(int weatherForecast_Id)
        {
            try
            {
                return _weatherForecastRepository.GetById(weatherForecast_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting weather forecast : {ex.ToString}");
            }
            return new WeatherForecast();
        }

        WeatherForecast? IWeatherForecastService.Update(int weatherForecast_Id, DateTime date, string temperatureC, string temperatureF, string summary, string description, string humidity, string precipitation)
        {
            try
            {
                var updateWeatherForecast = _weatherForecastRepository.Update(weatherForecast_Id, date, temperatureC, temperatureF, summary, description, humidity, precipitation);
                return updateWeatherForecast;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
