using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Behaviours.Norse;
using Persistence.Creational;
using Persistence.Entities;

namespace Persistence.Repositories
{
    public interface IWeatherForecastRepository
    {
        Task<List<WeatherForecast>> GetAll();
    }

    internal class WeatherForecastRepository(IWeatherForecastContext context) : IWeatherForecastRepository
    {
        private readonly DbSet<WeatherForecastEntity> _table = context.WeatherForcastEntities;

        public async Task<List<WeatherForecast>> GetAll()
        {
            return await _table.Select(s => new WeatherForecast()
            {
                Summary = s.Summary,
                TemperatureC = s.TemperatureC,
                Date = s.Date,
            }).ToListAsync();
        }
    }

}
