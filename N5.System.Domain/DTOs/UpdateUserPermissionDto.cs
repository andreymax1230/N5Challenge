using N5.Domain.Eda.Interfaces.DTOs;

namespace N5.System.Domain.DTOs;

public class UpdateUserPermissionDto : IPayloadMessageDTO
{
    public int Id { get; set; }
    public string EventId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int PermissionTypeId { get; set; }

    public DateTime DatePermission { get; set; }
}
