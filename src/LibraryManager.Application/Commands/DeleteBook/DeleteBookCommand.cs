using LibraryManager.Application.Results;
using MediatR;

namespace LibraryManager.Application.Commands.DeleteBook;

public class DeleteBookCommand : IRequest<Result>
{
    public int Id { get; private set; }

    public DeleteBookCommand(int id)
    {
        Id = id;
    }
}
