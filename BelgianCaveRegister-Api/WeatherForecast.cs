﻿namespace BelgianCaveRegister_Api
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
        public int Site_Id { get; set; }
    }
}
