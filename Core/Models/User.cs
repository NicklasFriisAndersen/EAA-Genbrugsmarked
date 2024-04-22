using MongoDB.Bson;

namespace Core.Models;

public class User
{
    public ObjectId Id { get; set; }
    
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    
    public string Role { get; set; }
    
    public List<Order> Orders { get; set; }
    
    public List<Listing> Listings { get; set; }
}