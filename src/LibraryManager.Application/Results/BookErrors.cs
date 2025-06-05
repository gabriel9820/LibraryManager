using System.Net;

namespace LibraryManager.Application.Results;

public static class BookErrors
{
    public static readonly Error BookNotFound = new(HttpStatusCode.NotFound, "Livro não encontrado");
    public static readonly Error BookUnavailable = new(HttpStatusCode.BadRequest, "Livro indisponível");
    public static readonly Error BookConcurrencyConflict = new(HttpStatusCode.Conflict, "O livro já foi emprestado a outro usuário");
}
