using Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;

namespace CleanArcitecture2025.Server.Controllers
{
    [ApiController]
    [Route("weatherforecast")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastRepository _weatherForcastRepository;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            Persistence.Repositories.WeatherForecastRepository weatherForcastRepository
            )
        {
            _logger = logger;
            _weatherForcastRepository=weatherForcastRepository;
        }

        [HttpGet]
        public async Task<List<WeatherForecast>> Get()
        {
            return await _weatherForcastRepository.GetAll();
        }

        [HttpPost]
        public async Task Create()
        {
            await _weatherForcastRepository.Create();
        }
    }
}
