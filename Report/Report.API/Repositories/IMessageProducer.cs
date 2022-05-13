using RabbitMQ.Client;

namespace Report.API.Repositories
{
    public interface IMessageProducer
    {
        public void SendMessage<T>(T message, IConnection connection);
    }
}
