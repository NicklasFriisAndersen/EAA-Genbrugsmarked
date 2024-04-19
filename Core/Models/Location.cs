using MongoDB.Bson;

namespace Core.Models;

public class Location
{
    public ObjectId LocationID { get; set; }
    
    public string Name { get; set; }
    
    public string OpeningHours { get; set; }
}