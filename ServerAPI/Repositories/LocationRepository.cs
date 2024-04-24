using System;
using Core.Models;
using MongoDB.Driver;

namespace ServerAPI.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private string connectionString =
            "mongodb+srv://gruppe3mini:gruppe3projekt@genbrugshjemmeside.l92667j.mongodb.net/?retryWrites=true&w=majority&appName=Genbrugshjemmeside";

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<Location> collection;
        
        public LocationRepository()
        {
            mongoClient = new MongoClient(connectionString);

            database = mongoClient.GetDatabase("Genbrugsmarked");

            collection = database.GetCollection<Location>("Location");
        }

        public List<Location> SendLocations()
        {
            var filter = Builders<Location>.Filter.Empty;
            return collection.Find(filter).ToList();
        }

        public List<Location> SortListingsByLocation(string lname)
        {
            return collection.Find<Location>(location => location.Name.Equals(lname,StringComparison.OrdinalIgnoreCase)).ToList();
        }

        
    }
}