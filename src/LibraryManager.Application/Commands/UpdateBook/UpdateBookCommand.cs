using LibraryManager.Application.Results;
using MediatR;

namespace LibraryManager.Application.Commands.UpdateBook;

public class UpdateBookCommand : IRequest<Result>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int PublicationYear { get; set; }
    public bool IsAvailable { get; set; }
}
