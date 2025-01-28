using Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;

namespace CleanArcitecture2025.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
 
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForcastRepository _weatherForcastRepository;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            Persistence.Repositories.WeatherForcastRepository weatherForcastRepository
            )
        {
            _logger = logger;
            _weatherForcastRepository=weatherForcastRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<List<WeatherForecast>> Get()
        {
            return await _weatherForcastRepository.GetAll();
        }
    }
}
