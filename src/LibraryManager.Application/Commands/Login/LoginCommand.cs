using LibraryManager.Application.Models;
using LibraryManager.Application.Results;
using MediatR;

namespace LibraryManager.Application.Commands.Login;

public class LoginCommand : IRequest<Result<LoginViewModel>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
