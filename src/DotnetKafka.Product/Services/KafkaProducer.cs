using Confluent.Kafka;

namespace DotnetKafka.Product.Services;

public class KafkaProducer
{
    private readonly ProducerConfig _config = new()
    {
        BootstrapServers = "kafka:9092",
        ClientId = "prductDemo",

    };

    public async Task ProduceMessage(string topic, string message)
    {
        try
        {
            using var producer = new ProducerBuilder<Null, string>(_config).Build();
            var result = producer.ProduceAsync(topic, new Message<Null, string> { Value = message }).GetAwaiter().GetResult();
            Console.WriteLine($"Message has been send{result.Status}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException.Message);
            throw ex;
        }

    }
}