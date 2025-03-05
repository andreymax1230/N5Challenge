namespace N5.System.Domain.Entities;

public class UserPermission : BaseEntity
{
    public int PermissionTypeId { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime DatePermission { get; set; }
    public virtual PermissionType PermissionType { get; set; }
}
