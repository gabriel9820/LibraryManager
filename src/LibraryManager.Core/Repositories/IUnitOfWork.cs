namespace LibraryManager.Core.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
