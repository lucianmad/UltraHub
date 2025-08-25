using MediatR;
using UltraHub.Application.Common.Models;

namespace UltraHub.Application.Features.Auth.Commands.Register;

public record RegisterCommand(string Email, string Username, string Password, string ConfirmPassword) : IRequest<Result<RegisterResponseDto>>;