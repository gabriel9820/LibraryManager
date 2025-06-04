using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;

namespace LibraryManager.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly LibraryManagerDbContext _dbContext;

    public UserRepository(LibraryManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);

        return user.Id;
    }
}
