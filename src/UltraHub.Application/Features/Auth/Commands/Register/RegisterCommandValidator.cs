using FluentValidation;

namespace UltraHub.Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{

    public RegisterCommandValidator()
    {

        RuleFor(u => u.Username)
            .NotEmpty().WithMessage("Username is required")
            .MinimumLength(5).WithMessage("Username should be at least 5 characters long")
            .MaximumLength(50).WithMessage("Username should not exceed 50 characters")
            .WithMessage("Username is already taken");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid")
            .MaximumLength(50).WithMessage("Email should not exceed 50 characters")
            .WithMessage("Email is already taken");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password should be at least 8 characters long")
            .MaximumLength(50).WithMessage("Password should not exceed 50 characters");
        
        RuleFor(u => u.ConfirmPassword)
            .Equal(u => u.Password).WithMessage("Passwords do not match");
    }
}