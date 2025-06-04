namespace LibraryManager.Infrastructure.Auth;

public interface IAuthService
{
    string HashPassword(string password);
    string GenerateJWT(string userId, string email, string role);
}
