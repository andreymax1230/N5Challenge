using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;
using N5.Presentation.Api.Controllers;
using N5.RequestReply.Eda.Interface;
using N5.System.Domain.DTOs;
using N5.UnitTest.Fake;
using Xunit;

namespace N5.UnitTest.Controllers;

[TestFixture]
public class UserPermissionControllerTest
{
    [Fact]
    public async Task GenerateUserPermission()
    {
        var request = new Faker<CreateUserPermissionDto>().GenerateItemFake();
        var response = new Faker<ResponseCreateUserPermissionDto>().GenerateItemFake();

        Mock<IRequestReplayService> mockRequestReplyService = new();
        mockRequestReplyService.Setup(a => a.WaitProducer<ResponseCreateUserPermissionDto>(It.IsAny<CreateUserPermissionDto>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>()))
            .Returns(Task.FromResult(response));

        var controller = new UserPermissionController(mockRequestReplyService.Object);
        var responseController = ((OkObjectResult)(await controller.Post(request)).Result).Value as ResponseCreateUserPermissionDto;

        NUnit.Framework.Assert.Multiple(() =>
        {
            NUnit.Framework.Assert.That(responseController, Is.Not.Null);
            NUnit.Framework.Assert.IsTrue(responseController.Response);
        });
    }

    [Fact]
    public async Task UpdateUserPermission()
    {
        var request = new Faker<UpdateUserPermissionDto>().GenerateItemFake();
        var response = new Faker<ResponseUpdateUserPermissionDto>().GenerateItemFake();

        Mock<IRequestReplayService> mockRequestReplyService = new();
        mockRequestReplyService.Setup(a => a.WaitProducer<ResponseUpdateUserPermissionDto>(It.IsAny<UpdateUserPermissionDto>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>()))
            .Returns(Task.FromResult(response));

        var controller = new UserPermissionController(mockRequestReplyService.Object);
        var responseController = ((OkObjectResult)(await controller.Put(request)).Result).Value as ResponseUpdateUserPermissionDto;

        NUnit.Framework.Assert.Multiple(() =>
        {
            NUnit.Framework.Assert.That(responseController, Is.Not.Null);
            NUnit.Framework.Assert.IsTrue(responseController.Response);
        });
    }

    [Fact]
    public async Task GetUsersPermissionSucess()
    {
        var request = new Faker<RequestGetUserPermissionDto>().GenerateItemFake();
        var response = new Faker<ResponseGetUserPermissionDto>().GenerateItemFake();

        Mock<IRequestReplayService> mockRequestReplyService = new();
        mockRequestReplyService.Setup(a => a.WaitProducer<ResponseGetUserPermissionDto>(It.IsAny<RequestGetUserPermissionDto>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>()))
            .Returns(Task.FromResult(response));

        var controller = new UserPermissionController(mockRequestReplyService.Object);
        var responseController = ((OkObjectResult)(await controller.Get(request)).Result).Value as ResponseGetUserPermissionDto;

        NUnit.Framework.Assert.Multiple(() =>
        {
            NUnit.Framework.Assert.That(responseController, Is.Not.Null);
            NUnit.Framework.Assert.That(responseController.Response, Is.Not.Null);
            NUnit.Framework.Assert.AreEqual(6, responseController.Response.Count);
        });
    }
}