using LibraryManager.Application.Results;
using LibraryManager.Core.Repositories;
using LibraryManager.Infrastructure.Auth;
using MediatR;

namespace LibraryManager.Application.Commands.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Result<int>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public CreateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IAuthService authService)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = _authService.HashPassword(request.Password);
        var user = request.ToEntity(hashedPassword);

        var id = await _userRepository.CreateAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return id;
    }
}
