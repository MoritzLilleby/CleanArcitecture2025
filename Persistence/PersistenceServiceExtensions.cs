using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceExtensions
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IWeatherForecastContext, WeatherForecastContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
            services.AddScoped<IGreekWeatherForecastRepository, GreekWeatherForecastRepository>();
            services.AddScoped<INorseWeatherForecastRepository, NorseWeatherForecastRepository>();

            services.AddScoped<IWeatherForecastRepositoryFacade, WeatherForecastRepositoryFacade>();
        }

    }
}
