using MediatR;
using Microsoft.AspNetCore.Identity;
using UltraHub.Application.Common.Interfaces;
using UltraHub.Application.Common.Models;
using UltraHub.Domain.Entities;
using UltraHub.Domain.Enums;

namespace UltraHub.Application.Features.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<RegisterResponseDto>>
{
    private readonly IJwtService _jwtService;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public RegisterCommandHandler(IJwtService jwtService, IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
    {
        _jwtService = jwtService;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<RegisterResponseDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Email = request.Email,
            Username = request.Username,
            Role = Role.User
        };
        
        user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
        
        await _userRepository.AddAsync(user, cancellationToken);
        
        var token = _jwtService.GenerateToken(user.Id, user.Role, user.Username, user.Email);
        
        return Result<RegisterResponseDto>.Success(
            new RegisterResponseDto(user.Id, user.Username, user.Email, token));
    }

}