using Application.Contracts;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Persistence.EF.Repositories.interfaces;

namespace CleanArcitecture2025.Server.Controllers.@public
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1.0/weatherforecast")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEFWeatherforecastRepository _eFWeatherforecastRepository;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IEFWeatherforecastRepository repository
            )
        {
            _logger = logger;
            _eFWeatherforecastRepository=repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<WeatherForecast>>> GetAll()
        {
            var result = await _eFWeatherforecastRepository.GetAll();

            var finalResult =  result.Select(x => new WeatherForecast
            {
                Date = x.Date,
                TemperatureC = x.TemperatureC,
                Summary = x.Summary,
            }).ToList();

            return finalResult;
        }

    }
}
