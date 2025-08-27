namespace UltraHub.Application.Common.Errors;

public sealed record Error(string Code, string Message, ErrorType Type)
{
    public IDictionary<string, string[]>? FieldErrors { get; init; }
    
    public static Error NotFound(string code, string message)
    {
        return new Error(code, message, ErrorType.NotFound);
    }

    public static Error Conflict(string code, string message)
    {
        return new Error(code, message, ErrorType.Conflict);
    }

    public static Error Validation(IDictionary<string, string[]> errors)
    {
        return new Error("Validation.Failed", "One or more fields are invalid", ErrorType.Validation)
        {
            FieldErrors = errors
        };
    }

    public static Error Unauthorized(string code, string message)
    {
        return new Error(code, message, ErrorType.Unauthorized);
    }
}