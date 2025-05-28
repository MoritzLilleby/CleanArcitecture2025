using Application.Contracts;
using Asp.Versioning;
using CleanArchitecture.Persistence.EF.Repositories.interfaces;
using CleanArchitecture.Rabbit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture2025.Server.Controllers.@public
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1.0/weatherforecast")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IEFWeatherforecastRepository _eFWeatherforecastRepository;
        private readonly Sender rabbitSenderProgram;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IEFWeatherforecastRepository repository,
            Sender rabbitSenderProgram
            )
        {
            _logger = logger; 
            _eFWeatherforecastRepository=repository;
            this.rabbitSenderProgram=rabbitSenderProgram;
        }

        [HttpGet]
        public async Task<ActionResult<List<WeatherForecast>>> GetAll()
        {
            await this.rabbitSenderProgram.Send("WeatherForecastController.GetAll", "hello");

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
