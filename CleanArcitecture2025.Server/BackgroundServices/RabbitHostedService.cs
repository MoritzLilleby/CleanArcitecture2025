
using Rabbit.Receiver;

namespace CleanArcitecture2025.Server.BackgroundServices
{
    public class RabbitHostedService : BackgroundService
    {
        private readonly RabbitProgram rabbitProgram;

        public RabbitHostedService(RabbitProgram rabbitProgram) 
        {
            this.rabbitProgram=rabbitProgram;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await rabbitProgram.Receiver();
        }
    }
}
