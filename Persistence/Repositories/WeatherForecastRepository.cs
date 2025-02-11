using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Creational;
using Persistence.Entities;

namespace Persistence.Repositories
{
    public class WeatherForecastRepository(IWeatherForecastContext context)
    {
        private readonly DbSet<WeatherForecastEntity> _table = context.WeatherForcastEntities;

        public async Task Create()
        {
            var forcast = new WeatherForecastEntity();

            var factory = new WeatherGodVisitorFactory();

            forcast.Accept(factory.CreateWeatherGodVisitor());

            await _table.AddAsync(forcast);

            await context.SaveChangesAsync();
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
