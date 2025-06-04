using LibraryManager.Application.Results;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.DeleteBook;

public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, Result>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBookHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);

        if (book is null)
        {
            return BookErrors.BookNotFound;
        }

        _bookRepository.Delete(book);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
