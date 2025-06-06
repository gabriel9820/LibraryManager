using System.Net;

namespace LibraryManager.Application.Results;

public static class LoanErrors
{
    public static readonly Error LoanNotFound = new(HttpStatusCode.NotFound, "Empréstimo não encontrado");
    public static readonly Error LoanConcurrencyConflict = new(HttpStatusCode.Conflict, "O livro já foi emprestado a outro usuário");
    public static readonly Error LoanAlreadyReturned = new(HttpStatusCode.BadRequest, "Empréstimo já foi devolvido");
}
