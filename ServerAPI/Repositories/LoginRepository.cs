using Core.Models;
using MongoDB.Driver;

namespace ServerAPI.Repositories;

public class LoginRepository : ILoginRepository
{
    // Assuming you have a way to access your database here
    private readonly IMongoCollection<User> _users;

    public LoginRepository()
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
        var user = GetUserByUserName(username);
        if (user != null)
        {
            // Directly comparing plaintext passwords
            return user.Password == password;
        }
        return false;
    }

}
