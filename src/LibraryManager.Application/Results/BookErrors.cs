using System.Net;

namespace LibraryManager.Application.Results;

public static class BookErrors
{
    public static readonly Error BookNotFound = new(HttpStatusCode.NotFound, "Livro não encontrado");
    public static readonly Error BookUnavailable = new(HttpStatusCode.BadRequest, "Livro indisponível");
}
