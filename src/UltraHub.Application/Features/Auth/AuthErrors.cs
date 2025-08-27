using UltraHub.Application.Common.Errors;

namespace UltraHub.Application.Features.Auth;

public static class AuthErrors
{
    public static readonly Error InvalidCredentials =
        Error.Unauthorized("Auth.InvalidCredentials", "The email or password is incorrect.");
    public static readonly Error EmailAlreadyTaken =
        Error.Conflict("Auth.EmailAlreadyTaken", "The email is already taken");
    public static readonly Error UsernameAlreadyTaken =
        Error.Conflict("Auth.UsernameAlreadyTaken", "The username is already taken");
    public static readonly Error UserNotFound =
        Error.NotFound("Auth.UserNotFound", "User not found");
}