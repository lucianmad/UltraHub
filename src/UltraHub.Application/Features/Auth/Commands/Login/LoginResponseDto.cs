namespace UltraHub.Application.Features.Auth.Commands.Login;

public record LoginResponseDto(
    int Id,
    string Username,
    string Email,
    string Token);