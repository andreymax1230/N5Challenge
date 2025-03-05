using N5.Domain.Eda.Interfaces.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.System.Domain.DTOs;

public class RequestGetUserPermissionDto : IPayloadMessageDTO
{
    public string EventId { get; set; }
}
