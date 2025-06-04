using LibraryManager.Application.Results;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Commands.CreateBook;

public class CreateBookHandler : IRequestHandler<CreateBookCommand, Result<int>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = request.ToEntity();

        var id = await _bookRepository.CreateAsync(book);
        await _unitOfWork.SaveChangesAsync();

        return id;
    }
}
