namespace UltraHub.Application.Features.Auth.Commands.Register;

public record RegisterResponseDto(
    int Id,
    string Username,
    string Email,
    string Token);