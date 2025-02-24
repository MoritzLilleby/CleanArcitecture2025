using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;
using Persistence.EF.Entities;
using Persistence.EF.Repositories.interfaces;

namespace Persistence.EF.Repositories
{

    internal class WeatherForecastRepository(IWeatherForecastContext context) : IEFWeatherforecastRepository
    {
        private readonly DbSet<WeatherForecastEntity> _table = context.WeatherForcastEntities;

        public Task Create()
        {
            throw new NotImplementedException();
        }

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
