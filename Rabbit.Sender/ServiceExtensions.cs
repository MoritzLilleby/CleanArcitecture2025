using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Sender
{
    public static class ServiceExtensions
    {
        public static void AddRabbitSender(this IServiceCollection services/*, IConfiguration configuration*/)
        {

            services.AddSingleton<IRabbitProgram, RabbitProgram>();

            //services.Configure<RabbitOptions>(configuration.GetSection("Rabbit"));

        }
    }
}
