using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.System.Domain.DTOs;

public class GetUserPermissionDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int PermissionTypeId { get; set; }

    public DateTime DatePermission { get; set; }
}
