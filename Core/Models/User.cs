using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string? Id { get; set; }

    public string Username { get; set; } = "";

    public string Password { get; set; } = "";

    public string Email { get; set; } = "";

    public string Role { get; set; } = "Buyer";
    
    
}