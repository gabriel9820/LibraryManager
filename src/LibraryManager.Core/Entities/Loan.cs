namespace LibraryManager.Core.Entities;

public class Loan : BaseEntity
{
    public int UserId { get; private set; }
    public int BookId { get; private set; }
    public DateTime LoanDate { get; private set; }
    public DateTime ExpectedReturnDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }

    /* Navigation properties */
    public User User { get; private set; }
    public Book Book { get; private set; }

    protected Loan() { }

    public Loan(int userId, int bookId, DateTime expectedReturnDate)
    {
        UserId = userId;
        BookId = bookId;
        LoanDate = DateTime.UtcNow;
        ExpectedReturnDate = expectedReturnDate;
        ReturnDate = null;
    }

    public void ReturnBook()
    {
        ReturnDate = DateTime.UtcNow;
    }
}
