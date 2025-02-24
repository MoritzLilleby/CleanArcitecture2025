using Application.Contracts;
using Persistence.EF.Repositories.interfaces;
using Rabbit.Sender;

namespace Persistence.EF.Repositories
{
    public interface IWeatherForecastRepositoryFacade
    {
        Task CreateGreekWeather();
        Task CreateNorseWeather();
        Task<List<WeatherForecast>> GetAll();
    }

    public sealed class WeatherForecastRepositoryFacade : IWeatherForecastRepositoryFacade
    {
        private readonly IGreekWeatherForecastRepository _greekWeatherForecastRespositor;
        private readonly INorseWeatherForecastRepository _norseWeatherForecastRepository;
        private readonly IEFWeatherforecastRepository weatherForecastRepository;
        private readonly IRabbitProgram rabbitProgram;

        public WeatherForecastRepositoryFacade
            (
                IGreekWeatherForecastRepository greekWeatherForecastRespositor,
                INorseWeatherForecastRepository norseWeatherForecastRepository,
                IEFWeatherforecastRepository weatherForecastRepository,
                IRabbitProgram rabbitProgram
            )
        {
            _greekWeatherForecastRespositor=greekWeatherForecastRespositor;
            _norseWeatherForecastRepository=norseWeatherForecastRepository;

            this.weatherForecastRepository=weatherForecastRepository;
            this.rabbitProgram=rabbitProgram;
        }

        public async Task CreateGreekWeather()
        {
            await _greekWeatherForecastRespositor.Create();
        }

        public async Task CreateNorseWeather()
        {
            await _norseWeatherForecastRepository.Create();
        }

        public async Task<List<WeatherForecast>> GetAll()
        {
            await Task.Delay(3000);

            await rabbitProgram.Send("WeatherForecastRepositoryFacade.GetAll()");

            return await weatherForecastRepository.GetAll();

        }
    }
}
