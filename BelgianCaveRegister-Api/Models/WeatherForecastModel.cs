namespace BelgianCaveRegister_Api.Models
{
    public class WeatherForecastModel
    {
        public DateTime Date { get; set; }
        public string? TemperatureC { get; set; }
        public string? TemperatureF { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public string? Humidity { get; set; }
        public string? Precipitation { get; set;}
        public int Site_Id { get; set; }
    }
}
