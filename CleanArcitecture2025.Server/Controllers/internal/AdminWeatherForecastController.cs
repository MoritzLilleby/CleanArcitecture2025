using Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Persistence.EF.Repositories;

namespace CleanArcitecture2025.Server.Controllers.@internal
{
    [ApiController]
    [Route("adin/weatherforecast/")]
    public class AdminWeatherForecastController : ControllerBase
    {

        private readonly ILogger<AdminWeatherForecastController> _logger;
        private readonly IWeatherForecastRepositoryFacade _weatherForecastRepositoryFacade;

        public AdminWeatherForecastController(
            ILogger<AdminWeatherForecastController> logger,
            IWeatherForecastRepositoryFacade weatherForecastRepositoryFacade
            )
        {
            _logger = logger;
            _weatherForecastRepositoryFacade=weatherForecastRepositoryFacade;
        }

        [HttpPost]
        [Route("norse")]
        public async Task CreateNorse()
        {
            await _weatherForecastRepositoryFacade.CreateNorseWeather();
        }

        [HttpPost]
        [Route("greek")]
        public async Task CreateGreek()
        {
            await _weatherForecastRepositoryFacade.CreateGreekWeather();
        }
    }
}
