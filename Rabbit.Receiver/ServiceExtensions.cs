using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Receiver
{
    public static class ServiceExtensions
    {
        public static void AddRabbitReceiver(this IServiceCollection services /*, IConfiguration configuration*/)
        {

            //services.AddSingleton<IConnectionFactory>(sp => new ConnectionFactory
            //{
            //    HostName = "localhost",
            //    UserName = "guest",
            //    Password = "guest"
            //});

            services.AddHostedService<RabbitProgram>();

            //services.Configure<RabbitOptions>(configuration.GetSection("Rabbit"));
        }
    }
}
