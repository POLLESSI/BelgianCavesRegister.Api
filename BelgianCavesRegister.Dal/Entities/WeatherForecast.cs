﻿
namespace BelgianCavesRegister.Dal.Entities
{
    public class WeatherForecast
    {
        public int WeathreForecast_Id { get; set; }
        public DateTime Date { get; set; }
        public string? TemperatureC { get; set; }
        public string? TemperatureF => 32 + (string)("TemperatureC / 0.5556");
        public string? Summary { get; set; }
        public string? Description { get; set;}
        public string? Humidity { get; set; }
        public string? Precipitation { get; set; }
        public bool Active { get; set; }
    }
}
