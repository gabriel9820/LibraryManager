using LibraryManager.Application.Results;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.CreateBook;

public class CreateBookHandler : IRequestHandler<CreateBookCommand, Result<int>>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Result<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = request.ToEntity();

        var id = await _bookRepository.CreateAsync(book);

        return id;
    }
}
