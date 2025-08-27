using UltraHub.Application.Common.Errors;

namespace UltraHub.Application.Common.Models;

public sealed record Result
{
    public bool IsSuccess { get; init; }
    public bool IsFailure => !IsSuccess;
    public Error? Error { get; init; }
    
    private Result() {}
    
    public static Result Success() => new Result {IsSuccess = true};
    public static Result Failure(Error error) => new Result {IsSuccess = false, Error = error};
}

public sealed record Result<T>
{
    public bool IsSuccess { get; init; }
    public bool IsFailure => !IsSuccess;
    public Error? Error { get; init; }
    public T? Value { get; init; }
    
    private Result() {}
    
    public static Result<T> Success(T value) => new() {IsSuccess = true, Value = value};
    public static Result<T> Failure(Error error) => new() {IsSuccess = false, Error = error};
}