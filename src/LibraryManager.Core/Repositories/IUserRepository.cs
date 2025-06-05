using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories;

public interface IUserRepository
{
    Task<int> CreateAsync(User user);
    Task<User?> GetByEmailAsync(string email);
}
