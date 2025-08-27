using MediatR;
using Microsoft.AspNetCore.Mvc;
using UltraHub.API.Extensions;
using UltraHub.Application.Features.Auth.Commands.Login;
using UltraHub.Application.Features.Auth.Commands.Register;

namespace UltraHub.API.Controllers;

[ApiController]
[Route("api/auth")]
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
        return result.ToActionResult(this);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        var result = await _mediator.Send(command);
        return result.ToActionResult(this);
    }
}