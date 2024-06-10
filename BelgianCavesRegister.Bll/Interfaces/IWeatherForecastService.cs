using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.WeatherForecast;

namespace BelgianCavesRegister.Bll.Interfaces
{
    public interface IWeatherForecastService
    {
        bool Create(WeatherForecast weatherForecast);
        void CreateWeatherForecast(WeatherForecast weatherForecast);
        IEnumerable<WeatherForecast?> GetAll();
        WeatherForecast? GetById(int weatherForecast_Id);
        WeatherForecast? Delete(int weatherForecast_Id);
        WeatherForecast? Update(DateTime date, string temperatureC, string temperatureF, string summary, string description, string humidity, string precipitation, int site_Id, int weatherForecast_Id);
    }
}
