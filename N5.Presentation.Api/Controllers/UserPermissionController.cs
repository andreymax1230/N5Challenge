using Microsoft.AspNetCore.Mvc;
using N5.Events;
using N5.RequestReply.Eda.Interface;
using N5.System.Domain.DTOs;

namespace N5.Presentation.Api.Controllers;

public class UserPermissionController(IRequestReplayService requestReplayService) : ApiBaseController(requestReplayService)
{
    [HttpPost]
    public async Task<ActionResult<bool>> Post([FromBody] CreateUserPermissionDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var response = await RequestReplayService.WaitProducer<ResponseCreateUserPermissionDto>(request, UserEvent.GeneratePermission, UserEvent.GenerateGenericSucessEvent, new TimeSpan(0, 0, 70));
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<bool>> Put([FromBody] UpdateUserPermissionDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var response = await RequestReplayService.WaitProducer<ResponseUpdateUserPermissionDto>(request, UserEvent.UpdatePermission, UserEvent.GenerateGenericSucessEvent, new TimeSpan(0, 0, 70));
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<ResponseGetUserPermissionDto>> Get([FromQuery] RequestGetUserPermissionDto request)
    {
        var response = await RequestReplayService.WaitProducer<ResponseGetUserPermissionDto>(request, UserEvent.GetPermission, UserEvent.GenerateGenericSucessEvent, new TimeSpan(0, 0, 70));
        return Ok(response);
    }
}