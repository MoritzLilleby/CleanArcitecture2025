using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddPersistence(configuration);
        }

    }
}
