using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Dapper;

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
                string sql = "INSERT INTO WeatherForecast (Date, TemperatureC, TemperatureF, Summary, Description, Humidity, Precipitation) VALUES " +
                    "(@Date, @TemperatureC, TemperatureF, Summary, Description, Humidity, Precipitation)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Date", weatherForecast.Date);
                parameters.Add("@TemperatureC", weatherForecast.TemperatureC);
                parameters.Add("@TemperatureF", weatherForecast.TemperatureF);
                parameters.Add("@Summary", weatherForecast.Summary);
                parameters.Add("@Description", weatherForecast.Description);
                parameters.Add("@Precipitation", weatherForecast.Precipitation);
                return _connection.Execute(sql, parameters) > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error encoding WeatherForecast: {ex.ToString}");
            }
            return false;
        }

        public void CreateWeatherForecast(WeatherForecast weatherForecast)
        {
            try
            {
                string sql = "INSERT INTO WeatherForecast (Date, TemperatureC, TemperatureF, Summary, Description, Humidity, Precipitation)";
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Creating Error: {ex.ToString}");
            }
        }

        public WeatherForecast Delete(int weatherForecast_Id)
        {


            try
            {
                string sql = "DELETE FROM WeatherForecast WHERE WeatherForecast_Id = @weatherForecast_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@weatherForecast_Id", weatherForecast_Id);
                return _connection.QueryFirst<WeatherForecast>(sql, weatherForecast_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting weather forecast: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<WeatherForecast> GetAll()
        {
            string sql = "SELECT * FROM WeatherForecast";
            return _connection.Query<WeatherForecast?>(sql);
        }

        public WeatherForecast GetById(int weatherForecast_Id)
        {
            try
            {
                string sql = "SELECT * FROM WEATHERFORECAST WHERE WeatherForecast_Id = @weatherForecast_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@weatherForecast_Id", weatherForecast_Id);
				return _connection.QueryFirst<WeatherForecast?>(sql, parameters);
			}
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting Weather Forecast: {ex.ToString}");
            }
            return null;
        }

        public WeatherForecast Update(int weatherForecast_Id, DateTime date, string? temperatureC, string? temperatureF, string? summary, string? description, string? humidity, string? presipitation)
        {
            try
            {
                string sql = "UPDATE WeatherForecast SET WeatherForecast_Id = @weatherForecast_Id WHERE WeatherForecast_Id = @weatherForecast_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@weatherForecast_Id", weatherForecast_Id);
                parameters.Add("date", date);
                parameters.Add("temperatureC", temperatureC);
                parameters.Add("temperatureF", temperatureF);
                parameters.Add("summary", summary);
                parameters.Add("description", description);
                parameters.Add("humidity", humidity);
                parameters.Add("presipitation", presipitation);
                return _connection.QueryFirst<WeatherForecast>(sql, parameters);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Weather Forecast: {ex}");
            }
            return new WeatherForecast();
        }
    }
}
