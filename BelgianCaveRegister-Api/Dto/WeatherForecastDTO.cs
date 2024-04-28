namespace BelgianCaveRegister_Api.Dto
{
    public class WeatherForecastDTO
    {
        public DateTime Date { get; set; }
        public string? TemperatureC { get; set; }
        public string? TempratetureF { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public string? Humidity { get; set; }
        public string? Precipitation { get; set; }
        public bool Active { get; set; }
    }
}
