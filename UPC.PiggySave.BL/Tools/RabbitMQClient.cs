using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPC.PiggySave.BL.Tools
{
    public class RabbitMQClient
    {
        public void EnviarMensaje(string cola, string mensaje) {
            var factory = new ConnectionFactory() { 
                HostName = "18.218.223.184",
                Port = 5672,
                VirtualHost = "/",
                Password = "admin",
                UserName = "admin"
            };

            using (var connection = factory.CreateConnection()) {
                using (var channel = connection.CreateModel()) {
                    channel.QueueDeclare(cola, false, false, false, null);
                    var body = Encoding.UTF8.GetBytes(mensaje);
                    channel.BasicPublish("", cola, null, body);
                }
            }
        }
    }
}
