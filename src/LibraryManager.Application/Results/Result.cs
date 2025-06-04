namespace LibraryManager.Application.Results;

public class Result
{
    public bool IsSuccess { get; init; }
    public Error Error { get; init; }

    public Result(bool isSuccess = true, Error? error = default)
    {
        IsSuccess = isSuccess;
        Error = error ?? Error.None;
    }

    public static Result Success() => new();
    public static Result Failure(Error error) => new(false, error);

    public static implicit operator Result(Error error) => new(false, error);
}

public class Result<T> : Result
{
    public T? Data { get; init; }

    public Result(T? data, bool isSuccess = true, Error? error = null) : base(isSuccess, error)
    {
        Data = data;
    }

    public static Result<T> Success(T data) => new(data);

    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator Result<T>(Error error) => new(default, false, error);
}