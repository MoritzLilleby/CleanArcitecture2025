namespace Rabbit.Receiver
{
    using Microsoft.Extensions.Hosting;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;
    using System.Text;

    public class RabbitProgram : IHostedService
    {
        //private readonly IConnectionFactory _connectionFactory;

        //public RabbitProgram(IConnectionFactory connectionFactory)
        //{
        //    _connectionFactory = connectionFactory;
        //}

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Receiver();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Clean up resources if needed
            return Task.CompletedTask;
        }


        public async Task Receiver()
        {
            try
            {
                var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
                var connection = await factory.CreateConnectionAsync();
                var channel = await connection.CreateChannelAsync();

                //using var connection = await _connectionFactory.CreateConnectionAsync();
                //using var channel = await connection.CreateChannelAsync();

                await channel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                Console.WriteLine(" [*] Waiting for messages.");

                var consumer = new AsyncEventingBasicConsumer(channel);
                consumer.ReceivedAsync += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($" [x] Received {message}");
                    return Task.CompletedTask;
                };

                await channel.BasicConsumeAsync("hello", autoAck: true, consumer: consumer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Implement retry logic or other error handling as needed
            }
        }
    }

}
