using MediatR;
using N5.Events;
using N5.Kafka.Eda.Attribute;
using N5.Kafka.Eda.Interface;
using N5.Kafka.Eda.Interfaces;
using N5.Kafka.Eda.Model;
using N5.Kafka.Eda.Utilities;
using N5.System.Application.UserPermission.Queries;
using N5.System.Domain.DTOs;
using N5.System.Integrator.Mapper;

namespace N5.System.Integrator.EventIntegrator;

[KafkaTopicAttribute(UserEvent.GetPermission)]
public class GetUserPermissionIntegrator(IMediator _mediator,
                                         IKafkaProducerService _kafkaProducerService) : IKafkaEvent
{
    public async Task Handler(KafkaMessage meesage, CancellationToken token)
    {
        var entityMessage = meesage.Value.ToDeserializeJSON<RequestGetUserPermissionDto>();
        var entityMap = MapperConfig.Mapper.Map<UserPermissionQuery>(entityMessage);
        var response = await _mediator.Send(entityMap);
        response.Topic = UserEvent.GenerateGenericSucessEvent;
        await _kafkaProducerService.PublishAsync(UserEvent.GenerateGenericSucessEvent, response);
    }
}
