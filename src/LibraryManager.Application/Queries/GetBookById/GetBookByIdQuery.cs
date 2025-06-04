using LibraryManager.Application.Models;
using LibraryManager.Application.Results;
using MediatR;

namespace LibraryManager.Application.Queries.GetBookById;

public class GetBookByIdQuery : IRequest<Result<BookViewModel>>
{
    public int Id { get; private set; }

    public GetBookByIdQuery(int id)
    {
        Id = id;
    }
}
