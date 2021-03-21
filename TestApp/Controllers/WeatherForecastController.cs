using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Controllers.Dto;
using TestApp.Repository;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("weather_forecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DataContext _dataContext;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetAll()
        {
            var weatherForecastSet = _dataContext.Set<WeatherForecast>();
            return weatherForecastSet.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<WeatherForecast> GetById([FromRoute] Guid id)
        {
            var weatherForecastSet = _dataContext.Set<WeatherForecast>();
            var weatherForecast = weatherForecastSet.FirstOrDefault(x => x.Id == id);
            if (weatherForecast != null)
            {
                return weatherForecast;
            }
            throw new ArgumentException();
        }

        [HttpPost]
        public async Task<WeatherForecastResponseDto> Post([FromBody] WeatherForecastRequestDto request)
        {
            var id = Guid.NewGuid();
            var entity = new WeatherForecast
            {
                Id = id,
                TemperatureC = request.TemperatureC,
                Summary = request.Summary
            };
            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

            return new WeatherForecastResponseDto
            {
                Id = id
            };
        }
    }
}
