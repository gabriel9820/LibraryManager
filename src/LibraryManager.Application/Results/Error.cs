using System.Net;

namespace LibraryManager.Application.Results;

public class Error
{
    public int Code { get; init; }
    public string Description { get; init; }

    public Error(HttpStatusCode code, string description)
    {
        Code = (int)code;
        Description = description;
    }

    public static readonly Error None = new(default, string.Empty);
}
