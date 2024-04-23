using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Models;

public class Role
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    public string Name { get; set; }
}