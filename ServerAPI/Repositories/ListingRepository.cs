using System;
using Core.Models;
using MongoDB.Driver;

namespace ServerAPI.Repositories
{
	public class ListingRepository : IListingRepository
	{

        private string connectionString = "mongodb+srv://gruppe3mini:gruppe3projekt@genbrugshjemmeside.l92667j.mongodb.net/?retryWrites=true&w=majority&appName=Genbrugshjemmeside";

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<Listing> collection;
        
        IMongoCollection<Location> locationCollection;
       


        public ListingRepository()
        {
            mongoClient = new MongoClient(connectionString);

            database = mongoClient.GetDatabase("Genbrugsmarked");

            collection = database.GetCollection<Listing>("Listing");
            locationCollection = database.GetCollection<Location>("Location");
        }

        public void insertOneListing(Listing listing)
        {
            collection.InsertOne(listing);
        }

        public List<Listing> getAllItems()
        {
            var filter = Builders<Listing>.Filter.Empty;

            return collection.Find(filter).ToList();
        }

        public List<Listing> SortListingsByCategory(string cname)
        {   
            return collection.Find<Listing>(item => item.Category.Equals(cname,StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<Location> SortListingsByLocation(string lname)
        {
            return locationCollection.Find<Location>(location => location.Name.Equals(lname, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}

