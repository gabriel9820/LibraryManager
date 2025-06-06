using LibraryManager.Application.Results;
using MediatR;

namespace LibraryManager.Application.Commands.ReturnLoan;

public class ReturnLoanCommand : IRequest<Result<string>>
{
    public int LoanId { get; private set; }

    public ReturnLoanCommand(int loanId)
    {
        LoanId = loanId;
    }
}
