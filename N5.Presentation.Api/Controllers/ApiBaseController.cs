using Microsoft.AspNetCore.Mvc;
using N5.RequestReply.Eda.Interface;

namespace N5.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiBaseController : Controller
{
    protected IRequestReplayService RequestReplayService;

    public ApiBaseController(IRequestReplayService requestReplayService) => RequestReplayService = requestReplayService;
}