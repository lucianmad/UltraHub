namespace UltraHub.Application.Common.Models;

public sealed record Result
{
    public bool IsSuccess { get; init; }
    public bool IsFailure => !IsSuccess;
    public string Error { get; init; } = string.Empty;
    
    private Result() {}
    
    public static Result Success() => new Result {IsSuccess = true};
    public static Result Failure(string error) => new Result {IsSuccess = false, Error = error};
}

public sealed record Result<T>
{
    public bool IsSuccess { get; init; }
    public bool IsFailure => !IsSuccess;
    public string Error { get; init; } = string.Empty;
    public T? Value { get; init; }
    
    private Result() {}
    
    public static Result<T> Success(T value) => new() {IsSuccess = true, Value = value};
    public static Result<T> Failure(string error) => new() {IsSuccess = false, Error = error};
}