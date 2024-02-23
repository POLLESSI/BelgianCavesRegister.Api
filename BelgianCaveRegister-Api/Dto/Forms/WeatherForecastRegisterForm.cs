using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class WeatherForecastRegisterForm
    {
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Celcius Temperatures are required ! ")]
        [DisplayName("Temperature C° : ")]
        public string TemperatureC { get; set; }
        [DisplayName("Temperature F° : ")]
        public string TemperatureF { get; set; }
        [Required(ErrorMessage = "The Summary is required")]
        [MinLength(2)]
        [MaxLength(256)]
        [DisplayName("Summary : ")]
        public string Summary { get; set; }


        [Required(ErrorMessage = "Description is required ! ")]
        [MinLength(4)]
        [MaxLength(256)]
        [DisplayName("Description : ")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Humidity is required ! ")]
        [DisplayName("Humidity : ")]
        public string Humidity { get; set; }
        [Required(ErrorMessage = "Precipitation is required ! ")]
        [DisplayName("Precipitation : ")]
        public string Precipitation { get; set; }
    }
}
