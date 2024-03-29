﻿using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;

namespace Send
{
    class Send
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory(){ HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                for (int i = 0; i < 10; i++)
                {
                    var message = $"Message nr {i+1} Hello World!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                        routingKey: "hello",
                        basicProperties: null,
                        body: body);
                    Console.WriteLine(" [x] Sent {0}", message);

                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
