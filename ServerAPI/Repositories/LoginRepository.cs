using Core.Models;
using MongoDB.Driver;

namespace ServerAPI.Repositories;

public class LoginRepository : ILoginRepository
{
    // Assuming you have a way to access your database here
    private readonly IMongoCollection<User> _users;
    private string connectionString = "mongodb+srv://gruppe3mini:gruppe3projekt@genbrugshjemmeside.l92667j.mongodb.net/?retryWrites=true&w=majority&appName=Genbrugshjemmeside";

    IMongoClient mongoClient;

    IMongoDatabase database;

    IMongoCollection<User> collection;
    public LoginRepository()
    {
        mongoClient = new MongoClient(connectionString);

        database = mongoClient.GetDatabase("Genbrugsmarked");

        _users = database.GetCollection<User>("User");
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
