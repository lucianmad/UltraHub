using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UltraHub.Application.Common.Errors;
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
    private readonly IValidator<RegisterCommand> _validator;

    public RegisterCommandHandler(IJwtService jwtService, IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IValidator<RegisterCommand> validator)
    {
        _jwtService = jwtService;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _validator = validator;
    }

    public async Task<Result<RegisterResponseDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            var fieldErrors = validationResult.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
            
            return Result<RegisterResponseDto>.Failure(Error.Validation(fieldErrors));
        }
        
        if (!await _userRepository.IsEmailAvailableAsync(request.Email, cancellationToken))
        {
            return Result<RegisterResponseDto>.Failure(AuthErrors.EmailAlreadyTaken);
        }

        if (!await _userRepository.IsUsernameAvailableAsync(request.Username, cancellationToken))
        {
            return Result<RegisterResponseDto>.Failure(AuthErrors.UsernameAlreadyTaken);
        }
        
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