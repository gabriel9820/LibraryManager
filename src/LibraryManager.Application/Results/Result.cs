namespace LibraryManager.Application.Results;

public class Result
{
    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }

    public Result(bool isSuccess = true, string message = "")
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public static Result Success() => new();
    public static Result Error(string message) => new(false, message);

    public static implicit operator Result(string message) => new(false, message);
}

public class Result<T> : Result
{
    public T? Data { get; private set; }

    public Result(T? data, bool isSuccess = true, string message = "") : base(isSuccess, message)
    {
        Data = data;
    }

    public static Result<T> Success(T data) => new(data);

    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator Result<T>(string message) => new(default, false, message);
}