using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka.Producer
{
    public interface IKafkaProducer
    {
        public void Produce(string message);
    }
}
