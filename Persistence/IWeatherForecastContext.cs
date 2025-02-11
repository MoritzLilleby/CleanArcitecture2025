using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IWeatherForecastContext
    {
        internal DbSet<WeatherForecastEntity> WeatherForcastEntities { get; }

        internal Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }

}
