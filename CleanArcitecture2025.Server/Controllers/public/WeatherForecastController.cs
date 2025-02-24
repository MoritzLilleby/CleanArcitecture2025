using Application.Contracts;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Persistence.EF.Repositories;

namespace CleanArcitecture2025.Server.Controllers.@public
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1.0/weatherforecast")]
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
        public async Task<ActionResult<List<WeatherForecast>>> GetAll()
        {
            return await _weatherForecastRepositoryFacade.GetAll();
        }

    }
}
