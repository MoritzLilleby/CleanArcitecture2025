using Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Behaviours;
using Persistence.Entities;

namespace Persistence.Repositories
{
    public class WeatherForcastRepository(IWeatherForcastContext context)
    {
        private readonly DbSet<WeatherForcastEntity> _table = context.WeatherForcastEntities;

        public async Task Create() 
        {
            var forcast = new WeatherForcastEntity();

            forcast.Accept(new Zeus());

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
