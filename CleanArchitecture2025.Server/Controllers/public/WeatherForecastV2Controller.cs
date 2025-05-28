using Application.Contracts;
using Asp.Versioning;
using CleanArchitecture.Persistence.Contracts;
using CleanArchitecture.Persistence.Dapper.Repositories.Interfaces;
using CleanArchitecture.Rabbit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture2025.Server.Controllers.@public
{
    [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v2.0/weatherforecast")]
    public class WeatherForecastV2Controller : ControllerBase
    {
        private readonly IDPWeatherForecastRepository _repository;

        private readonly Sender rabbitSenderProgram;

        public WeatherForecastV2Controller(
            IDPWeatherForecastRepository repository,
            Sender rabbitSenderProgram
            )
        {
            _repository = repository;
            this.rabbitSenderProgram=rabbitSenderProgram;
        }

        [HttpGet]
        public async Task<ActionResult<List<WeatherForecast>>> GetAll()
        {
            await this.rabbitSenderProgram.Send("WeatherForecastV2Controller.GetAll", "hello");
            var forecasts = await _repository.GetAll();
            return Ok(forecasts);
        }

    }
}
