using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.Bibliography;

namespace BelgianCavesRegister.Bll.Interfaces
{
    public interface IWeatherForecastService
    {
        bool Create(WeatherForecast weatherForecast);
        void CreateWeatherForecast(WeatherForecast weatherForecast);
        IEnumerable<WeatherForecast> GetAll();
        WeatherForecast? GetById(int weatherForecast_Id);
        WeatherForecast? Delete(int weatherForecast_Id);
        WeatherForecast? Update(int weatherForecast_Id, DateTime date, string temperatureC, string TemperatureF, string summary, string description, string humidity, string precipitation);
    }
}
