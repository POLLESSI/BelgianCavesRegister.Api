using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class WeatherForecastRegisterForm
    {
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Celcius Temperatures are required ! ")]
        [MinLength(2)]
        [MaxLength(4)]
        [DisplayName("Temperature C° : ")]
        public string? TemperatureC { get; set; }
        [MaxLength(4)]
        [DisplayName("Temperature F° : ")]
        public string? TemperatureF { get; set; }
        [Required(ErrorMessage = "The Summary is required")]
        [MinLength(2)]
        [MaxLength(256)]
        [DisplayName("Summary : ")]
        public string? Summary { get; set; }
        [Required(ErrorMessage = "Description is required ! ")]
        [MinLength(4)]
        [MaxLength(256)]
        [DisplayName("Description : ")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Humidity is required ! ")]
        [MinLength(2)]
        [MaxLength(4)]
        [DisplayName("Humidity : ")]
        public string? Humidity { get; set; }
        [Required(ErrorMessage = "Precipitation is required ! ")]
        [MinLength(2)]
        [MaxLength(8)]
        [DisplayName("Precipitation : ")]
        public string? Precipitation { get; set; }
        [Required]
        [DisplayName("Site Id : ")]
        public int Site_Id { get; set; }
    }
}
