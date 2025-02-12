using Application.Contracts;
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

        public WeatherForecastRepositoryFacade
            (
                IGreekWeatherForecastRepository greekWeatherForecastRespositor,
                INorseWeatherForecastRepository norseWeatherForecastRepository,
                IWeatherForecastRepository weatherForecastRepository
            )
        {
            _greekWeatherForecastRespositor=greekWeatherForecastRespositor;
            _norseWeatherForecastRepository=norseWeatherForecastRepository;

            this.weatherForecastRepository=weatherForecastRepository;
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
            return await weatherForecastRepository.GetAll();
        }
    }
}
