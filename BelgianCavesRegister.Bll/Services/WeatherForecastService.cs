using BelgianCavesRegister.Dal.Repository;
using BelgianCavesRegister.Bll;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using BelgianCavesRegister.Bll.Interfaces;
using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;

namespace BelgianCavesRegister.Bll.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
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

                Console.WriteLine($"Error creating Weather Forecast: {ex.ToString}");
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

                Console.WriteLine($"Error Creation Weather Forecast: {ex.ToString}");
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

                Console.WriteLine($"error deleting weather forecast: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<WeatherForecast?> GetAll()
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

                Console.WriteLine($"Error geting weather forecast: {ex.ToString}");
            }
            return null;
        }

        public WeatherForecast? Update(int weatherForecast_Id, DateTime date, string temperatureC, string temperatureF, string summary, string description, string humidity, string precipitation)
        {
            try
            {
                var updateWeatherForecast = _weatherForecastRepository.Update( weatherForecast_Id, date, temperatureC, temperatureF, summary, description, humidity, precipitation);
                return updateWeatherForecast;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating weather forecast: {ex}");
            }
            return new WeatherForecast();
        }
    }
}
