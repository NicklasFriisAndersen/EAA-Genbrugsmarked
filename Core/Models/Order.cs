using MongoDB.Bson;

namespace Core.Models;

public class Order
{
    public ObjectId Id { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public User User { get; set; }

    public List<Listing> Listings { get; set; }
}