using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string Id { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public User User { get; set; }

    public List<Listing> Listings { get; set; }
}