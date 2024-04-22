using MongoDB.Bson;

namespace Core.Models;

public class Role
{
    public ObjectId Id { get; set; }
    
    public string Name { get; set; }
}