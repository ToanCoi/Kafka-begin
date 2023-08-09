using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka.Consumer
{
    public class KafkaConsumer : IKafkaConsumer
    {
        public void Consume()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "my-group"
            };

            using(var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
            {
                consumer.Subscribe("my-topic");

                try
                {
                    while(true)
                    {
                        var consumerResult = consumer.Consume();
                        Console.WriteLine($"Received message '{consumerResult.Message.Value}' from partition '{consumerResult.TopicPartition.Partition}' offset '{consumerResult.TopicPartitionOffset.Offset}'");
                    }
                }
                catch (OperationCanceledException)
                {
                    
                }
                finally { consumer.Close(); }
            }
        }
    }
}
