using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public class User
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Username { get; set; } = "";

    public string Password { get; set; } = "";

    public string Email { get; set; } = "";

    public string Role { get; set; } = "Buyer";
    
    public List<Order>? Orders { get; set; }
    
    public List<Listing>? Listings { get; set; }
}