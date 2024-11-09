using Microsoft.AspNetCore.Http.Features;

namespace BlazorSignalRApp.Modules;

public class UserRepository
{
    private readonly List<User> _users = new List<User>();

    public User? ValidateUser(string username, string password)
    {
        return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }

    public bool AddUser(string username, string password)
    {
        if (_users.Any(u => u.Username == username))
        {
            // El usuario ya existe
            return false;
        }

        _users.Add(new User { Username = username, Password = password });
        return true;
    }
}

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}