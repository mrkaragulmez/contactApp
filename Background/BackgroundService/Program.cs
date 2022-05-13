using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Diagnostics;
using System.Text;

namespace BackgroundService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConnection connection = GetConnection();
            using IModel channel = connection.CreateModel();
            channel.QueueDeclare("reports", exclusive: false);
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                byte[] body = eventArgs.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            channel.BasicConsume(queue: "reports", autoAck: true, consumer: consumer);
            Console.ReadLine();
        }
        private static IConnection GetConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@rabbitmq:5672")
            };
            return connectionFactory.CreateConnection();
        }
    }
}
