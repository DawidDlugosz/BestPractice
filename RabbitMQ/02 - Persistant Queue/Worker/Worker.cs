using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Worker
{
    class Worker
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "task_queue",
                    durable: true,              // Queue won't be lost even if RabbitMQ restarts
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                channel.BasicQos(
                    prefetchSize: 0,
                    prefetchCount: 1,           // This tells RabbitMQ not to give more than one message to a worker at a time. Or, in other words, don't dispatch a new message to a worker until it has processed and acknowledged the previous one. Instead, it will dispatch it to the next worker that is not still busy.
                    global: false);

                Console.WriteLine(" [*] Waiting for messages.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);

                    int dots = message.Split('.').Length - 1;
                    Thread.Sleep(dots * 1000);

                    Console.WriteLine(" [x] Done");

                    channel.BasicAck(
                        deliveryTag: ea.DeliveryTag,    // Inform RabbitMQ that message was delivered correctly
                        multiple: false);
                };
                channel.BasicConsume(queue: "task_queue",
                    autoAck: false,             // Don't remove message from queue until RabbitMQ will not get deliveryTag from consumer
                    consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
