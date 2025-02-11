using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using Persistence.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    internal sealed class WeatherForecastContext : DbContext, IWeatherForecastContext
    {
        public WeatherForecastContext(DbContextOptions<WeatherForecastContext> options)
          : base(options) // Pass options to the base constructor
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new WeatherForecastTypeConfiguration().Configure(modelBuilder.Entity<WeatherForecastEntity>());
        }

        public DbSet<WeatherForecastEntity> WeatherForcastEntities { get; set; }

    }
}
