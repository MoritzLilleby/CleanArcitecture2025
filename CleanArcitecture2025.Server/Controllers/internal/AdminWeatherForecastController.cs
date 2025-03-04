using Microsoft.AspNetCore.Mvc;
using Persistence.Dapper.Repositories.Interfaces;
using Persistence.EF.Repositories.interfaces;

namespace CleanArcitecture2025.Server.Controllers.@internal
{
    [ApiController]
    [Route("adin/weatherforecast/")]
    public class AdminWeatherForecastController : ControllerBase
    {

        private readonly ILogger<AdminWeatherForecastController> _logger;
        private readonly IEFWeatherforecastRepository _eFWeatherforecastRepository;
        private readonly IDPWeatherForecastRepository _dPWeatherForecastRepository;

        public AdminWeatherForecastController(
            ILogger<AdminWeatherForecastController> logger,
            IEFWeatherforecastRepository eFWeatherforecastRepository,
            IDPWeatherForecastRepository dPWeatherForecastRepository
            )
        {
            _logger = logger;
            _eFWeatherforecastRepository=eFWeatherforecastRepository;
            _dPWeatherForecastRepository=dPWeatherForecastRepository;
        }


        [HttpPost]
        [Route("ef/norse")]
        public async Task CreateNorseWithEf()
        {
            await _eFWeatherforecastRepository.CreateNorseWeather();
        }

        [HttpPost]
        [Route("ef/greek")]
        public async Task CreateGreekWithEf()
        {
            await _eFWeatherforecastRepository.CreateGreekWeather();
        }


        [HttpPost]
        [Route("dp/norse")]
        public async Task CreateNorseWithDp()
        {
            await _dPWeatherForecastRepository.CreateNorseWeather();
        }

        [HttpPost]
        [Route("dp/greek")]
        public async Task CreateGreekWithDp()
        {
            await _dPWeatherForecastRepository.CreateGreekWeather();
        }
    }
}
