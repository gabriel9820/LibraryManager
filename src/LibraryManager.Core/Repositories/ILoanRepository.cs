using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories;

public interface ILoanRepository
{
    Task<int> CreateAsync(Loan loan);
    Task<Loan?> GetByIdAsync(int id);
}
