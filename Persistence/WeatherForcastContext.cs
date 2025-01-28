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
    internal class WeatherForcastContext : DbContext, IWeatherForcastContext
    {
        public WeatherForcastContext(DbContextOptions<WeatherForcastContext> options)
          : base(options) // Pass options to the base constructor
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new WeatherForcastTypeConfiguration().Configure(modelBuilder.Entity<WeatherForcastEntity>());
        }
        
        public DbSet<WeatherForcastEntity> WeatherForcastEntities { get; set; }

    }
}
