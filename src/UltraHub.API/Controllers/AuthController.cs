using MediatR;
using Microsoft.AspNetCore.Mvc;
using UltraHub.Application.Features.Auth.Commands.Register;

namespace UltraHub.API.Controllers;

[ApiController]
[Route("api/auth-controller")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return BadRequest(result.Error);
    }
    
}