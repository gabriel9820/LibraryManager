namespace LibraryManager.Core.Entities;

public class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string Role { get; private set; }

    /* Navigation Properties */
    public List<Loan> Loans { get; private set; } = [];

    protected User() { }

    public User(string name, string email, string passwordHash, string role)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
    }
}
