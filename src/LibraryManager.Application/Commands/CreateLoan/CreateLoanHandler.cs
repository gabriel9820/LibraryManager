using LibraryManager.Application.Results;
using LibraryManager.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Application.Commands.CreateLoan;

public class CreateLoanHandler : IRequestHandler<CreateLoanCommand, Result<int>>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateLoanHandler(ILoanRepository loanRepository, IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _loanRepository = loanRepository;
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.BookId);

        if (book is null)
        {
            return BookErrors.BookNotFound;
        }

        if (!book.IsAvailable)
        {
            return BookErrors.BookUnavailable;
        }

        book.MarkAsUnavailable();

        var loan = request.ToEntity();

        var id = await _loanRepository.CreateAsync(loan);

        try
        {
            await _unitOfWork.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return BookErrors.BookConcurrencyConflict;
        }

        return id;
    }
}
