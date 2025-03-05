using N5.Domain.Eda.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.System.Domain.DTOs
{
    public class ResponseGetUserPermissionDto : ResponseDTO
    {
        public List<GetUserPermissionDto> Response { get; set; }
    }
}
