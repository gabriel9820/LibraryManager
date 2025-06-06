using LibraryManager.Application.Results;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.ReturnLoan;

public class ReturnLoanHandler : IRequestHandler<ReturnLoanCommand, Result<string>>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReturnLoanHandler(ILoanRepository loanRepository, IUnitOfWork unitOfWork)
    {
        _loanRepository = loanRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<string>> Handle(ReturnLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.GetByIdAsync(request.LoanId);

        if (loan is null)
        {
            return LoanErrors.LoanNotFound;
        }

        if (loan.ReturnDate.HasValue)
        {
            return LoanErrors.LoanAlreadyReturned;
        }

        loan.MarkAsReturned();
        loan.Book?.MarkAsAvailable();

        await _unitOfWork.SaveChangesAsync();

        var overdueDays = loan.CalculateOverdueDays();

        if (overdueDays > 0)
        {
            return $"Empréstimo devolvido com {overdueDays} dias de atraso";
        }

        return "Empréstimo devolvido no prazo";
    }
}
