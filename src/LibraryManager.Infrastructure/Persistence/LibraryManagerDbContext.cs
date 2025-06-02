using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Persistence;

public class LibraryManagerDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<User> Users { get; set; }

    public LibraryManagerDbContext(DbContextOptions<LibraryManagerDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryManagerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
