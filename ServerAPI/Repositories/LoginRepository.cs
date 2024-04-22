using Core.Models;
using MongoDB.Driver;

namespace ServerAPI.Repositories;

public class LoginRepository : ILoginRepository
{
    // Assuming you have a way to access your database here
    private readonly IMongoCollection<User> _users;

    public LoginRepository(IMongoCollection<User> usersCollection)
    {
        _users = usersCollection;
    }

    public User GetUserByUserName(string username)
    {
        // Fetch the user from the database by username
        return _users.Find(u => u.Username == username).FirstOrDefault();
    }

    public bool Verify(string username, string password)
    {
        // Get the user by username
        var user = GetUserByUserName(username);
        if (user != null)
        {
            // Here, you should compare the provided password with the one stored in the database
            // Make sure to hash the password before comparison if you're storing hashed passwords
            // For example: return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }
        return false;
    }
}
