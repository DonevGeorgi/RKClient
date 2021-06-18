using Client.DL.Memory;
using Client.Models.Models;
using MessagePack;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading;

namespace Client.DL.RabbitMq
{
    public class RabbitConsumer
    {
        public static void Consume(IModel rabbitMqChannel)
        {
            string queueName = "ComputerQueue";

            rabbitMqChannel.QueueDeclare(queue: queueName,
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            rabbitMqChannel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            int messageCount = Convert.ToInt16(rabbitMqChannel.MessageCount(queueName));
            Console.WriteLine(" Listening to the queue. This channels has {0} messages on the queue", messageCount);

            var consumer = new EventingBasicConsumer(rabbitMqChannel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                //var message = Encoding.UTF8.GetString(body);
                //Console.WriteLine(" Location received: " + message);  
                rabbitMqChannel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                Thread.Sleep(1000);
                InMemoryDb.Computers.Enqueue(MessagePackSerializer.Deserialize<Computer>(body));
            };
            rabbitMqChannel.BasicConsume(queue: queueName,
                                    autoAck: false,
                                    consumer: consumer);
        }
    }
}
