using LibraryManager.Application.Models;
using LibraryManager.Application.Results;
using MediatR;

namespace LibraryManager.Application.Queries.GetAllBooks;

public class GetAllBooksQuery : IRequest<Result<IEnumerable<BookViewModel>>>
{

}
