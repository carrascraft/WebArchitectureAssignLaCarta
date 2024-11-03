using Microsoft.AspNetCore.Http.Features;

namespace BlazorSignalRApp.Modules;

public class AuthService
{
    private readonly UserRepository _userRepository;
    private readonly Dictionary<string, User> _activeSessions = new Dictionary<string, User>();

    public AuthService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public bool Login(string username, string password, out string sessionId)
    {
        var user = _userRepository.ValidateUser(username, password);
        if (user != null)
        {
            sessionId = Guid.NewGuid().ToString();
            _activeSessions[sessionId] = user;
            return true;
        }
        sessionId = string.Empty;
        return false;
    }

    public bool IsUserLoggedIn(string sessionId)
    {
        return _activeSessions.ContainsKey(sessionId);
    }

    public void Logout(string sessionId)
    {
        _activeSessions.Remove(sessionId);
    }
}