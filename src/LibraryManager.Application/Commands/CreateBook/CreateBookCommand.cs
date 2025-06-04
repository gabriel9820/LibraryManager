using LibraryManager.Application.Results;
using LibraryManager.Core.Entities;
using MediatR;

namespace LibraryManager.Application.Commands.CreateBook;

public class CreateBookCommand : IRequest<Result<int>>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PublicationYear { get; set; }
}

public static class CreateBookCommandExtensions
{
    public static Book ToEntity(this CreateBookCommand command)
    {
        return new Book(
            command.Title,
            command.Author,
            command.ISBN,
            command.PublicationYear);
    }
}
