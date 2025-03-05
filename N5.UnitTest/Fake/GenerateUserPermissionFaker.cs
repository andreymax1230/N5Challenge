using Bogus;
using N5.System.Domain.DTOs;

namespace N5.UnitTest.Fake;

public static class GenerateUserPermissionFaker
{
    public static CreateUserPermissionDto GenerateItemFake(this Faker<CreateUserPermissionDto> item)
    {
        item.RuleFor(a => a.EventId, z => Guid.NewGuid().ToString());
        item.RuleFor(a => a.DatePermission, z => DateTime.UtcNow);
        item.RuleFor(a => a.FirstName, z => z.Lorem.Lines(2));
        item.RuleFor(a => a.LastName, z => z.Name.FirstName());
        item.RuleFor(a => a.PermissionTypeId, z => z.Random.Int(1, 2000));
        return item.Generate();
    }

    public static UpdateUserPermissionDto GenerateItemFake(this Faker<UpdateUserPermissionDto> item)
    {

        item.RuleFor(a => a.EventId, z => Guid.NewGuid().ToString());
        item.RuleFor(a => a.DatePermission, z => DateTime.UtcNow);
        item.RuleFor(a => a.FirstName, z => z.Lorem.Lines(2));
        item.RuleFor(a => a.LastName, z => z.Name.FirstName());
        item.RuleFor(a => a.PermissionTypeId, z => z.Random.Int(1, 2000));
        return item.Generate();
    }

    public static ResponseCreateUserPermissionDto GenerateItemFake(this Faker<ResponseCreateUserPermissionDto> item)
    {
        item.RuleFor(a => a.EventId, z => Guid.NewGuid().ToString());
        item.RuleFor(a => a.Response, z => true);
        return item.Generate();
    }

    public static ResponseUpdateUserPermissionDto GenerateItemFake(this Faker<ResponseUpdateUserPermissionDto> item)
    {
        item.RuleFor(a => a.EventId, z => Guid.NewGuid().ToString());
        item.RuleFor(a => a.Response, z => true);
        return item.Generate();
    }
}
