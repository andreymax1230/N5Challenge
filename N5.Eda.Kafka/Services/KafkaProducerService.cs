using Confluent.Kafka;
using N5.Kafka.Eda.Interface;
using N5.Kafka.Eda.Utilities;
using N5.Kafka.Eda.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace N5.Kafka.Eda.Services;

public class KafkaProducerService(IProducer<Null, string> _producerKafka,
                                  IServiceProvider _serviceProvider) : IKafkaProducerService, IDisposable
{

    /// <summary>
    /// Suscribe Topics and consumer events
    /// </summary>
    public void SuscribeBuild()
    {
        IKafkaAgent kafkaAgent = _serviceProvider.GetService<IKafkaAgent>();
        ArgumentNullException.ThrowIfNull(kafkaAgent);
        kafkaAgent.Subscribe();
    }

    /// <summary>
    /// Send message Kafka
    /// </summary>
    /// <param name="topic">Topic Name</param>
    /// <param name="payload">Message</param>
    /// <returns></returns>
    public Task PublishAsync(string topic, object value) => Task.Factory.StartNew(async () =>
    {
        await _producerKafka.ProduceAsync(topic, new Message<Null, string> { Value = value.ToSerializeJSON() });
    });

    public void Dispose()
    {
        _producerKafka.Dispose();
    }
}
