using MediatR;
using Microsoft.AspNetCore.Identity;
using UltraHub.Application.Common.Interfaces;
using UltraHub.Application.Common.Models;
using UltraHub.Domain.Entities;

namespace UltraHub.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResponseDto>>
{
    private readonly IJwtService _jwtService;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public LoginCommandHandler(IJwtService jwtService, IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
    {
        _jwtService = jwtService;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<LoginResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user is null)
        {
            return Result<LoginResponseDto>.Failure("Invalid credentials");
        }

        if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) ==
            PasswordVerificationResult.Failed)
        {
            return Result<LoginResponseDto>.Failure("Invalid password");
        }
        
        var token = _jwtService.GenerateToken(user.Id, user.Role, user.Username, user.Email);
        
        return Result<LoginResponseDto>.Success(
            new LoginResponseDto(user.Id, user.Username, user.Email, token));
    }
}