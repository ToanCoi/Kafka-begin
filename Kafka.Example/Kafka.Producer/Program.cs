using Kafka.Producer;

Console.WriteLine("Please enter the message you want to send");

while(true)
{
    var message = Console.ReadLine();
    if(!string.IsNullOrEmpty(message))
    {
        IKafkaProducer producer = new KafkaProducer();
        producer.Produce(message);
    }
}