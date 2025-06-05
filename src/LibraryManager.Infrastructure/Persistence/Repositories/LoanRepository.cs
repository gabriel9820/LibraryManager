using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;

namespace LibraryManager.Infrastructure.Persistence.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly LibraryManagerDbContext _dbContext;

    public LoanRepository(LibraryManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateAsync(Loan loan)
    {
        await _dbContext.Loans.AddAsync(loan);

        return loan.Id;
    }
}
