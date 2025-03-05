using N5.Domain.Eda.Interfaces.DTOs;

namespace N5.System.Domain.DTOs;

public class CreateUserPermissionDto : IPayloadMessageDTO
{
    public string EventId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int PermissionTypeId { get; set; }

    public DateTime DatePermission { get; set; }
}