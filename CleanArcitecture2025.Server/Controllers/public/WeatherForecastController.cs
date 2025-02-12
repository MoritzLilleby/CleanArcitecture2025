using Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;

namespace CleanArcitecture2025.Server.Controllers.@public
{
    [ApiController]
    [Route("weatherforecast")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastRepositoryFacade _weatherForecastRepositoryFacade;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWeatherForecastRepositoryFacade weatherForecastRepositoryFacade
            )
        {
            _logger = logger;
            _weatherForecastRepositoryFacade=weatherForecastRepositoryFacade;
        }

        [HttpGet]
        public async Task<List<WeatherForecast>> GetAll()
        {
            return await _weatherForecastRepositoryFacade.GetAll();
        }

    }
}
