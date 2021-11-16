using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ_Receiver.Models;
using System;
using System.Text;

namespace RabbitMQ_Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "modal",
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    Category data = Helper<Category>.ByteArrayToGeneric(ea.Body.ToArray());
                    //var body = ea.Body.ToArray(); //string metinler için
                    //var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received => {0} {1}", data.Name, data.Description);
                };
                channel.BasicConsume(queue: "modal",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
