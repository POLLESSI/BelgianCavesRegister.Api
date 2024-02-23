using BelgianCaveRegister_Api.Models;
using System;
using System.Data.Entity.Infrastructure;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BelgianCaveRegister_Api
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public string? TemperatureC { get; set; }
        public string? TemperatureF => 32 + (string)("TemperatureC / 0.5556");
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public string? Humidity { get; set; }
        public string? Precipitation { get; set; }

        public static async Task<WeatherForecast> GetWeatherForecastFromApiAsync()
        {
            using (var httpClient = new HttpClient())
            {
                // Replace "Your api_EndPoint" with the actual endpoint for weather data
                var apiUrl = "https://www.meteocity.com/belgique";
                // Make the API call
                var response = await httpClient.GetAsync(apiUrl);
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var weatherData = JsonSerializer.Deserialize<WeatherForecastModel>(content);

                    // Map the API data to your WeatherFoercast model
                    return new WeatherForecast
                    {
                        Date = DateTime.Now,
                        TemperatureC = weatherData.TemperatureC,
                        Summary = weatherData.Description,
                        Description = weatherData.Description,
                        Humidity = weatherData.Humidity,
                        Precipitation = weatherData.Precipitation,
                    };
                }
                else
                {
                    // Handle the case when the API call fails
                    throw new Exception($"Failed to fetch weather data. Sratus code: {response.StatusCode}");
                }
            }
        }
    }
}
