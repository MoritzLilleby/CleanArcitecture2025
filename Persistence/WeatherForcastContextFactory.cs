using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    internal class WeatherForcastContextFactory : IDesignTimeDbContextFactory<WeatherForcastContext>
    {
        public WeatherForcastContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherForcastContext>();
            var connectionString = "Server=localhost;Database=WeatherForcast;Trusted_Connection=True;MultipleActiveResultSets=true; Encrypt=false";
            optionsBuilder.UseSqlServer(connectionString);

            return new WeatherForcastContext(optionsBuilder.Options);

        }
    }
}
