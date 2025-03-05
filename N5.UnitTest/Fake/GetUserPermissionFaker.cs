using Bogus;
using Bogus.DataSets;
using N5.Events;
using N5.System.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.UnitTest.Fake;

public static class GetUserPermissionFaker
{
    public static RequestGetUserPermissionDto GenerateItemFake(this Faker<RequestGetUserPermissionDto> item)
    {
        item.RuleFor(x => x.EventId, z => Guid.NewGuid().ToString());
        return item.Generate();
    }

    public static ResponseGetUserPermissionDto GenerateItemFake(this Faker<ResponseGetUserPermissionDto> item)
    {
        item.RuleFor(x => x.EventId, z => Guid.NewGuid().ToString());
        item.RuleFor(x => x.Topic, z => UserEvent.GenerateGenericSucessEvent);
        item.RuleFor(x => x.Response, z => new Faker<GetUserPermissionDto>().ListItemObjectFaker());
        return item.Generate();
    }

    public static List<GetUserPermissionDto> ListItemObjectFaker(this Faker<GetUserPermissionDto> item)
    {
        item.RuleFor(x => x.FirstName, z => z.Lorem.Lines(3));
        return item.Generate(6).ToList();
    }
 }
