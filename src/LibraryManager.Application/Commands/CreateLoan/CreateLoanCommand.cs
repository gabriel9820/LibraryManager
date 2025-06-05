using LibraryManager.Application.Results;
using LibraryManager.Core.Entities;
using MediatR;

namespace LibraryManager.Application.Commands.CreateLoan;

public class CreateLoanCommand : IRequest<Result<int>>
{
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime ExpectedReturnDate { get; set; }
}

public static class CreateLoanCommandExtensions
{
    public static Loan ToEntity(this CreateLoanCommand command)
    {
        return new Loan(
            command.UserId,
            command.BookId,
            command.ExpectedReturnDate);
    }
}
