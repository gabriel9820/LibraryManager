using LibraryManager.Application.Results;
using LibraryManager.Core.Entities;
using MediatR;

namespace LibraryManager.Application.Commands.CreateUser;

public class CreateUserCommand : IRequest<Result<int>>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}

public static class CreateUserCommandExtensions
{
    public static User ToEntity(this CreateUserCommand command, string hashedPassword)
    {
        return new User(
            command.Name,
            command.Email,
            hashedPassword,
            command.Role);
    }
}
