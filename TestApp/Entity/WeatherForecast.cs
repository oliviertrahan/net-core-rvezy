using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp
{
    [Table("weather_forecast")]
    public class WeatherForecast
    {
        [Key]
        public Guid Id { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }
    }
}
