using N5.Domain.Eda.Interfaces.DTOs;

namespace N5.System.Domain.DTOs;

public class RequestGetUserPermissionDto : IPayloadMessageDTO
{
    public string EventId { get; set; }
}
