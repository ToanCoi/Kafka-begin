using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka.Producer
{
    public class KafkaProducer : IKafkaProducer
    {
        public async void Produce(string message)
        {
            var config = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092"
            };

            using(var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                var messPush = new Message<Null, string>()
                {
                    Value = message
                };

                var deliveryResult = await producer.ProduceAsync("my-topic", messPush);

                Console.WriteLine($"Message delivered to {deliveryResult.TopicPartitionOffset.Offset}");
            }
        }
    }
}
