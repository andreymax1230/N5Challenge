using N5.Domain.Eda.Base;
using N5.Domain.Eda.Interfaces.DTOs;
using N5.Events;
using N5.Kafka.Eda.Attribute;
using N5.Kafka.Eda.Interface;
using N5.Kafka.Eda.Model;
using N5.Kafka.Eda.Utilities;
using N5.RequestReply.Eda.Entities.Model;
using N5.RequestReply.Eda.Helper;
using N5.RequestReply.Eda.Interface;
using Newtonsoft.Json;

namespace N5.RequestReply.Eda.Service;

[KafkaTopicAttribute(UserEvent.GenerateGenericSucessEvent)]
public class RequestReplyService : IRequestReplayService
{
    #region members
    private readonly IRequestReplayRepository _replyRepository;
    private readonly IKafkaProducerService _kafkaProducerService;
    #endregion


    public RequestReplyService(IRequestReplayRepository replyRepository, IKafkaProducerService kafkaProducerService)
    {
        _replyRepository = replyRepository;
        _kafkaProducerService = kafkaProducerService;
    }

    public async Task Handler(KafkaMessage meesage, CancellationToken token)
    {
        var messageEntity = meesage.Value.ToDeserializeJSON<ResponseDTO>();
        await _replyRepository.GenerateRequestReplyAsync(new Reply() { Id = HelperRequestReply.CreateEventId, EventId = messageEntity.EventId, Topic = messageEntity.Topic, Payload = meesage.Value, DateCreate = DateTime.UtcNow });
    }

    public async Task<T> WaitProducer<T>(IPayloadMessageDTO payload, string startTopic, string endTopic, TimeSpan? timeout)
    {
        payload.EventId = string.IsNullOrEmpty(payload.EventId) ? HelperRequestReply.CreateEventId : payload.EventId;
        timeout = new TimeSpan(0, 0, 20);
        await _kafkaProducerService.PublishAsync(startTopic, payload);
        var producer = new Producer() { Id = HelperRequestReply.CreateEventId, EventId = payload.EventId, Topic = startTopic };
        T? response = default;
        try
        {
            bool succeeded = false;
            while (!succeeded)
            {
                var endReply = await _replyRepository.HasReplyByIdSessionAsync(producer.EventId, endTopic);
                if (endReply > 0)
                {
                    var reply = await _replyRepository.GetReplyByIdSessionAsync(producer.EventId, endTopic);
                    response = JsonConvert.DeserializeObject<T>(reply.Payload);
                    succeeded = true;
                }
                else
                    await Task.Delay(50);
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error Request-Reply ({producer.EventId}) {ex.Message}");
        }
        finally
        {
            _replyRepository.DeleteReplyAsync(producer.EventId);
        }

        if (response == null) 
            throw new Exception($"Reply payload is null ({producer.EventId})");
        return response;
    }
}
