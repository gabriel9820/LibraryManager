using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories;

public interface IBookRepository
{
    Task<int> CreateAsync(Book book);
    void Delete(Book book);
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book?> GetByIdAsync(int id);
}
