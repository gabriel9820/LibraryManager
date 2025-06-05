using System.Net;

namespace LibraryManager.Application.Results;

public static class AuthErrors
{
    public static readonly Error InvalidCredentials = new(HttpStatusCode.BadRequest, "Email e/ou senha incorreto(s)");
}
