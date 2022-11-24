using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using UserService.Controllers;

namespace UserService.Services
{
    public class MessagingService
    {
        public readonly ConnectionFactory factory = new ConnectionFactory();

        public readonly IConnection connection;

        public readonly IModel userItemExchange;

        public readonly IModel userGatewayExchange;

        public readonly WishListUpdateController controller;
        public MessagingService(WishListUpdateController controller)
        {
            //Some values ommited
            factory.UserName = "";
            factory.Password = "";
            factory.HostName = "localhost";
            factory.Port = 5672;
            factory.VirtualHost = "";
            factory.DispatchConsumersAsync = true;
            connection = factory.CreateConnection();
            userItemExchange = connection.CreateModel();
            userItemExchange.ExchangeDeclare("userItemExchange", ExchangeType.Direct, true);
            userItemExchange.QueueDeclare("userItemQueue", true, false, false);
            userItemExchange.QueueBind("userItemQueue", "userItemExchange", "userItemRoutingKey");
            this.controller = controller;
        }

        public void receiveMessage()
        {
            var consumer = new AsyncEventingBasicConsumer(userItemExchange);
            consumer.Received += async (sender, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                await controller.Update();              
            };

            string consumerTag = userItemExchange.BasicConsume("userItemQueue", false, consumer);

        }


    }
}
