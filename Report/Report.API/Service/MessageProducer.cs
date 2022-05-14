using Newtonsoft.Json;
using RabbitMQ.Client;
using Report.API.Repositories;
using System.Text;

namespace Report.API.Service
{
    public class MessageProducer : IMessageProducer
    {
        public void SendMessage<T>(T message, IConnection connection)
        {
            using IModel channel = connection.CreateModel();
            channel.QueueDeclare("reports", exclusive: false);
            string json = JsonConvert.SerializeObject(message);
            byte[] body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "reports", body: body);
        }
    }
}
