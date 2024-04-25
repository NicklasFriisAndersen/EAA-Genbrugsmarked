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


        public ListingRepository()
        {
            mongoClient = new MongoClient(connectionString);

            database = mongoClient.GetDatabase("Genbrugsmarked");

            collection = database.GetCollection<Listing>("Listing");
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

        public List<Listing> SortListingsByLocation(string locationName)
        {
            return collection.Find<Listing>(item => item.Location.Name.Equals(locationName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Listing> SortListingsByStatus(string status)
        {
            return collection.Find<Listing>(item => item.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Listing> SortListingsByUserId(string userId)
        {
            var filter = Builders<Listing>.Filter.Eq("User.Id", userId);
            return collection.Find(filter).ToList();
        }
        
        public List<Listing> SortListingByPriceDescending(decimal price)
        {
            return collection.Aggregate().SortByDescending<Listing>(listing => listing.Price).ToList();
        }
        
        public List<Listing> SortListingByPriceAscending(decimal price)
        {
            return collection.Aggregate().SortBy<Listing>(listing => listing.Price).ToList();
        }
        
        public void DeleteListing(string listingId)
        {
            var filter = Builders<Listing>.Filter.Eq("Id", listingId);
            collection.DeleteOne(filter);
        }
        
        public void UpdateListing (Listing listing)
        {
            var filter = Builders<Listing>.Filter.Eq("Id", listing.Id);
            var update = Builders<Listing>.Update
                .Set(l => l.Category, listing.Category)
                .Set(l => l.Title, listing.Title)
                .Set(l => l.Description, listing.Description)
                .Set(l => l.Status, listing.Status)
                .Set(l => l.Price, listing.Price)
                .Set(l => l.Location, listing.Location);
            collection.UpdateOne(filter, update);
        }

    }
}

