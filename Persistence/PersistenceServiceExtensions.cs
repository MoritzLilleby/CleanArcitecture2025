using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Configuration;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceExtensions
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<IWeatherForcastContext, WeatherForcastContext>(options => 
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            //services.AddScoped<IWeatherForcastContext, WeatherForcastContext>();
            services.AddScoped<WeatherForcastRepository>();
        }

    }
}
