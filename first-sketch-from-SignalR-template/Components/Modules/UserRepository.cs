using Microsoft.AspNetCore.Http.Features;

namespace BlazorSignalRApp.Modules;

public class UserRepository
{
    private readonly List<User> _users = new List<User>
    {
        new User { Username = "chef1", Password = "chef1Pass" },
        new User { Username = "chef2", Password = "chef2Pass" }
    };

    public User? ValidateUser(string username, string password)
    {
        return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
}
