using MongoDB.Bson;

namespace Core.Models;

public class Listing
{
    public ObjectId Id { get; set; }

    public string Title { get; set; } = "";
    
    public string Description { get; set; } = "";

    public string Status { get; set; } = "Available";

    public decimal Price { get; set; } = 1;

    public string Category { get; set; } = "";

    public DateTime DatePosted { get; set; }
    
    public Location? Location { get; set; }
    
    public User? User { get; set; }

}

