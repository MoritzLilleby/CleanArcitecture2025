using CleanArchitecture.Rabbit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Dapper.Repositories.Interfaces;
using Persistence.EF.Repositories.interfaces;

namespace CleanArchitecture2025.Server.Controllers.@internal
{
    //[Authorize]
    [ApiController]
    [Route("api/admin/v1.0/weatherforecast/")]
    public class AdminWeatherForecastController : ControllerBase
    {

        private readonly ILogger<AdminWeatherForecastController> _logger;
        private readonly IEFWeatherforecastRepository _eFWeatherforecastRepository;
        private readonly IDPWeatherForecastRepository _dPWeatherForecastRepository;
        private readonly Sender rabbitSenderProgram;

        public AdminWeatherForecastController(
            ILogger<AdminWeatherForecastController> logger,
            IEFWeatherforecastRepository eFWeatherforecastRepository,
            IDPWeatherForecastRepository dPWeatherForecastRepository,
            Sender rabbitSenderProgram
            )
        {
            _logger = logger;
            _eFWeatherforecastRepository=eFWeatherforecastRepository;
            _dPWeatherForecastRepository=dPWeatherForecastRepository;
            this.rabbitSenderProgram=rabbitSenderProgram;
        }


        [HttpPost]
        [Route("ef/norse")]
        public async Task CreateNorseWithEf()
        {
            await this.rabbitSenderProgram.Send("CreateNorseWeatherWithEf", "hello");
            await _eFWeatherforecastRepository.CreateNorseWeather();
        }

        [HttpPost]
        [Route("ef/greek")]
        public async Task CreateGreekWithEf()
        {
            await this.rabbitSenderProgram.Send("CreateGreekWeatherkWithEf", "hello");
            await _eFWeatherforecastRepository.CreateGreekWeather();
        }


        [HttpPost]
        [Route("dp/norse")]
        public async Task CreateNorseWithDp()
        {
            await this.rabbitSenderProgram.Send("CreateNorseWeatherkWithDp", "hello");
            await _dPWeatherForecastRepository.CreateNorseWeather();
        }

        [HttpPost]
        [Route("dp/greek")]
        public async Task CreateGreekWithDp()
        {
            await this.rabbitSenderProgram.Send("CreateGreekWeatherkWitDp", "hello");
            await _dPWeatherForecastRepository.CreateGreekWeather();
        }
    }
}
