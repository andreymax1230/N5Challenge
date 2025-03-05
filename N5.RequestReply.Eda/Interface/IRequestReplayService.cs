using N5.Domain.Eda.Interfaces.DTOs;
using N5.Kafka.Eda.Interfaces;

namespace N5.RequestReply.Eda.Interface;

public interface IRequestReplayService : IKafkaEvent
{
    Task<T> WaitProducer<T>(IPayloadMessageDTO payload, string startTopic, string endTopic, TimeSpan? timeout);
}
