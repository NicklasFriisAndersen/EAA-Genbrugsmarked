using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public class Listing
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string? Id { get; set; }
    public string Title { get; set; }
    
    public string Description { get; set; } = "";

    public string Status { get; set; } = "Available";

    public decimal Price { get; set; } = 1;

    public string Category { get; set; } = "";

    public DateTime DatePosted { get; set; }
    
    public Location? Location { get; set; }
    
    public User? User { get; set; }

}

