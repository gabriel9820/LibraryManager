using LibraryManager.Application.Models;
using LibraryManager.Application.Results;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.GetAllBooks;

public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, Result<IEnumerable<BookViewModel>>>
{
    private readonly IBookRepository _bookRepository;

    public GetAllBooksHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Result<IEnumerable<BookViewModel>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllAsync();
        var result = books.Select(book => book.ToViewModel()).ToList();

        return result;
    }
}
