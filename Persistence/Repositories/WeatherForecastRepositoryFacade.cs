using Application.Contracts;
using Rabbit.Sender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
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
        private readonly IWeatherForecastRepository weatherForecastRepository;
        private readonly IRabbitProgram rabbitProgram;

        public WeatherForecastRepositoryFacade
            (
                IGreekWeatherForecastRepository greekWeatherForecastRespositor,
                INorseWeatherForecastRepository norseWeatherForecastRepository,
                IWeatherForecastRepository weatherForecastRepository,
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

            await this.rabbitProgram.Send("WeatherForecastRepositoryFacade.GetAll()");

            return await weatherForecastRepository.GetAll();

        }
    }
}
