using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQListener
{
    class Program
    {
        static void Main(string[] args)
        {
            String cola = "colaPS";
            var factory = new ConnectionFactory()
            {
                HostName = "18.218.223.184",
                Port = 5672,
                UserName = "admin",
                Password = "admin",
                VirtualHost = "/"
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(cola, false, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    channel.BasicConsume(cola, true, consumer);
                    consumer.Received += (sender, e) =>
                    {
                        var body = e.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(message);
                    };
                    //channel.BasicConsume(cola, true, consumer);
                    Console.ReadLine();
                }
            }
        }
    }
}
