using MongoDB.Bson;

namespace Core.Models;

public class Listing
{
    public ObjectId Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string Status { get; set; }
    
    public decimal Price { get; set; }
    
    public string Category { get; set; }
    
    public DateTime DatePosted { get; set; }
    
    public Location Location { get; set; }
    
    public User User { get; set; }

}

