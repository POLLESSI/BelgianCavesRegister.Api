﻿using System;
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
                string sql = "INSERT INTO WeatherForecast (Date, TemperatureC, TemperatureF, Summary, Description, Humidity, Precipitation, Site_Id) VALUES " +
                    "(@Date, @TemperatureC, @TemperatureF, @Summary, @Description, @Humidity, @Precipitation, @Site_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Date", weatherForecast.Date);
                parameters.Add("@TemperatureC", weatherForecast.TemperatureC);
                parameters.Add("@TemperatureF", weatherForecast.TemperatureF);
                parameters.Add("@Summary", weatherForecast.Summary);
                parameters.Add("@Description", weatherForecast.Description);
                parameters.Add("@Precipitation", weatherForecast.Precipitation);
                parameters.Add("@Site_Id", weatherForecast.Site_Id);

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
                string sql = "INSERT INTO WeatherForecast (Date, TemperatureC, TemperatureF, Summary, Description, Humidity, Precipitation, Site_Id)" +
                    " VALUES (@date, @temperatureC, @temperatureF, @summary, @description, @humidity, @precipitation, @site_Id)";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@date", weatherForecast.Date);
                parameters.Add("@temperatureC", weatherForecast.TemperatureC);
                parameters.Add("@temperatureF", weatherForecast.TemperatureF);
                parameters.Add("@summary", weatherForecast.Summary);
                parameters.Add("@description", weatherForecast.Description);
                parameters.Add("@humidity", weatherForecast.Humidity);
                parameters.Add("@precipitation", weatherForecast.Precipitation);
                parameters.Add("@site_Id", weatherForecast.Site_Id);

                _connection.Query(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Creating Error: {ex.ToString}");
            }
        }

        public WeatherForecast? Delete(int weatherForecast_Id)
        {


            try
            {
                string sql = "DELETE * FROM WeatherForecast WHERE WeatherForecast_Id = @weatherForecast_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@weatherForecast_Id", weatherForecast_Id);
                return _connection.QueryFirst<WeatherForecast>(sql, parameters);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting weather forecast: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<WeatherForecast?> GetAll()
        {
            string sql = "SELECT * FROM WeatherForecast";
            return _connection.Query<WeatherForecast?>(sql);
        }

        public WeatherForecast? GetById(int weatherForecast_Id)
        {
            try
            {
                string sql = "SELECT we.Date, we.TemperatureC, we.TemperatureF, we.Summary, we.Description, we.Humidity, we.Precipitation, we.Site_Id FROM WeatherForecast we JOIN Site si ON we.Site_Id WHERE WeatherForecast_Id = @weatherForecast_Id";
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

        public WeatherForecast? Update(DateTime date, string? temperatureC, string? temperatureF, string? summary, string? description, string? humidity, string? presipitation, int site_Id, int weatherForecast_Id)
        {
            try
            {
                string sql = "UPDATE WeatherForecast SET Date = @date, TemperatureC = @temperatureC, TemperatureF = @temperatureF, Summary = @summary, Description = @description, Humidity = @humidity, Presipitation = @presipitation, Site_Id = @site_Id WHERE WeatherForecast_Id = @weatherForecast_Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@date", date);
                parameters.Add("@temperatureC", temperatureC);
                parameters.Add("@temperatureF", temperatureF);
                parameters.Add("@summary", summary);
                parameters.Add("@description", description);
                parameters.Add("@humidity", humidity);
                parameters.Add("@presipitation", presipitation);
                parameters.Add("@site_Id", site_Id);
                parameters.Add("@weatherForecast_Id", weatherForecast_Id);

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