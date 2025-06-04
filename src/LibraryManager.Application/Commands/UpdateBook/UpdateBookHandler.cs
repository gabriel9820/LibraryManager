using LibraryManager.Application.Results;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.UpdateBook;

public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, Result>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBookHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);

        if (book is null)
        {
            return BookErrors.BookNotFound;
        }

        book.Update(
            request.Title,
            request.Author,
            request.ISBN,
            request.PublicationYear,
            request.IsAvailable);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
