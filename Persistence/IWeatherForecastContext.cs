using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence
{
    public interface IWeatherForecastContext
    {
        internal DbSet<WeatherForecastEntity> WeatherForcastEntities { get; }

        internal Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }

}
