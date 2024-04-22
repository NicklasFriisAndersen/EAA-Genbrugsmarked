using MongoDB.Bson;

namespace Core.Models;

public class Location
{
    public ObjectId Id { get; set; }
    
    public string Name { get; set; }
    
    public string OpeningHours { get; set; }
}