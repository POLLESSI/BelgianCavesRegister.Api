using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.WeatherForecast;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface IWeatherForecastRepository
    {
        bool Create(WeatherForecast weatherForecast);
        void CreateWeatherForecast(WeatherForecast weatherForecast);
        IEnumerable<WeatherForecast> GetAll();
        WeatherForecast GetById(int weatherForecast_Id);
        WeatherForecast Delete(int weatherForecast_Id);
        WeatherForecast Update(int weatherForecast_Id, DateTime date, string? temperatureC, string? temperatureF, string? summary, string? description, string? humidity, string? presipitation);
    }
}
