using LibraryManager.Application.Models;
using LibraryManager.Application.Results;
using LibraryManager.Core.Repositories;
using LibraryManager.Infrastructure.Auth;
using MediatR;

namespace LibraryManager.Application.Commands.Login;

public class LoginHandler : IRequestHandler<LoginCommand, Result<LoginViewModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public LoginHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<Result<LoginViewModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        var hashedPassword = _authService.HashPassword(request.Password);

        if (user is null || !user.CheckPassword(hashedPassword))
        {
            return AuthErrors.InvalidCredentials;
        }

        var token = _authService.GenerateJWT(user.Id.ToString(), user.Email, user.Role);
        var result = new LoginViewModel(token);

        return result;
    }
}
