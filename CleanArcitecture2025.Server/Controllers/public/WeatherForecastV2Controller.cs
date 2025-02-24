using Application.Contracts;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Persistence.Contracts;
using Persistence.Dapper.Repositories.Interfaces;

namespace CleanArcitecture2025.Server.Controllers.@public
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v2.0/weatherforecast")]
    public class WeatherForecastV2Controller : ControllerBase
    {

        private readonly IWeatherForecastRepository _repository;

        public WeatherForecastV2Controller(IDPWeatherForecastRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<WeatherForecast>>> GetAll()
        {
            var forecasts = await _repository.GetAll();
            return Ok(forecasts);
        }

    }
}
