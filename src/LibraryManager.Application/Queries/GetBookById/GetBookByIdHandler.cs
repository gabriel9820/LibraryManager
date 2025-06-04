using LibraryManager.Application.Models;
using LibraryManager.Application.Results;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.GetBookById;

public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Result<BookViewModel>>
{
    private readonly IBookRepository _bookRepository;

    public GetBookByIdHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Result<BookViewModel>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);

        if (book is null)
        {
            return BookErrors.BookNotFound;
        }

        var result = book.ToViewModel();

        return result;
    }
}
