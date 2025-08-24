using MediatR;
using UltraHub.Application.Common.Models;

namespace UltraHub.Application.Features.Auth.Commands.Login;

public record LoginCommand(string Email, string Password) : IRequest<Result<LoginResponseDto>>;