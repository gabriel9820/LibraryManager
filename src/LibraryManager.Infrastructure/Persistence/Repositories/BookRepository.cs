using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryManagerDbContext _dbContext;

    public BookRepository(LibraryManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateAsync(Book book)
    {
        await _dbContext.Books.AddAsync(book);

        return book.Id;
    }

    public void Delete(Book book)
    {
        _dbContext.Books.Remove(book);
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _dbContext.Books
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _dbContext.Books
            .SingleOrDefaultAsync(b => b.Id == id);
    }
}
