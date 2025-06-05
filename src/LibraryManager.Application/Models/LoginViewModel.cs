namespace LibraryManager.Application.Models;

public class LoginViewModel
{
    public string Token { get; private set; }

    public LoginViewModel(string token)
    {
        Token = token;
    }
}
