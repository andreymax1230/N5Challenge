using N5.Domain.Eda.Base;

namespace N5.System.Domain.DTOs;

public class ResponseGetUserPermissionDto : ResponseDTO
{
    public List<GetUserPermissionDto> Response { get; set; }
}
