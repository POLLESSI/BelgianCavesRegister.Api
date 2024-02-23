using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Dal.Repository
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly SqlConnection _connection;

        public WeatherForecastRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public bool Create(WeatherForecast weatherForecast)
        {
            try
            {
                string sql = "INSERT INTO WeatherForecast (Description, Humidity, Precipitation) VALUES " +
                    "(@Description, @Humidity, @Precipitation)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Description", weatherForecast.Description);
                parameters.Add("@Humidity", weatherForecast.Humidity);
                parameters.Add("@Precipitation", weatherForecast.Precipitation);
                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error encoding WeatherForecast : {ex.ToString}");
            }
            return false;
        }

        public void CreateWeatherForecast(WeatherForecast weatherForecast)
        {
            try
            {
                string sql = "INSERT INTO WeatherForecast (Description, Humidity, Precipitation) " +
                    "VALUES (@description, @humidity, @precipitation)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@description", weatherForecast.Description);
                parameters.Add("@humidity", weatherForecast.Humidity);
                parameters.Add("@precipitation", weatherForecast.Precipitation);
                _connection.Query(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Creating Error : {ex.ToString}");
            }
        }

        public WeatherForecast? Delete(int weatherForcast_Id)
        {
            try
            {
                string sql = "DELETE FROM WeatherForecast WHERE WeatherForecast_Id = @weatherForecast_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@weatherForecast_Id", weatherForcast_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting weather forecast : {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<WeatherForecast> GetAll()
        {
            try
            {
                string sql = "SELECT * FROM WeatherForecast";
                return _connection.Query<WeatherForecast>(sql);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Weather Forecasts : {ex.ToString}");
            }
            return Enumerable.Empty<WeatherForecast>();
        }

        public WeatherForecast? GetById(int weatherForcast_Id)
        {
            try
            {
                string sql = "SELECT * FROM WEATHERFORECAST WHERE WeatherForecast_Id = @weatherForecast_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@weatherForecast_Id", weatherForcast_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Weather Forecast : {ex.ToString}");
            }
            return new WeatherForecast();
        }

        public WeatherForecast? Update(int weatherForecast_Id, DateTime date, string temperatureC, string temperatureF, string summary, string description, string humidity, string precipitation)
        {
            try
            {
                string sql = "UPDATE WeatherForecast SET WeatherForecast_Id = @weatherForecast_Id WHERE WeatherForecast_Id = @weatherForecast_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@weatherForecast_Id", weatherForecast_Id);
                parameters.Add("description", description);
                parameters.Add("humidity", humidity);
                parameters.Add("precipitation", precipitation);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating weather forecast : {ex}");
            }
            return new WeatherForecast();
        }
    }
}
