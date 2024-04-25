using System;
using Core.Models;
using MongoDB.Driver;
using ServerAPI.Repositories;

namespace ServerAPI.Repositories
{
    public class ListingRepository : IListingRepository
{
    // MongoDB connection string with credentials and configuration.
    private string connectionString = "mongodb+srv://[credentials]@host/?retryWrites=true&w=majority&appName=App";

    // MongoClient object to manage connections to the database.
    IMongoClient mongoClient;

    // Reference to the database containing the listings.
    IMongoDatabase database;

    // Collection within the MongoDB database where listings are stored.
    IMongoCollection<Listing> collection;

    // Constructor to initialize database connections and collection reference.
    public ListingRepository()
    {
        mongoClient = new MongoClient(connectionString); // Connects to MongoDB using the connection string.
        database = mongoClient.GetDatabase("Genbrugsmarked"); // Accesses the 'Genbrugsmarked' database.
        collection = database.GetCollection<Listing>("Listing"); // Accesses the 'Listing' collection.
    }

    // Inserts a new listing into the database.
    public void insertOneListing(Listing listing)
    {
        collection.InsertOne(listing); // Uses MongoDB's InsertOne method to add the listing.
    }

    // Retrieves all listings from the collection.
    public List<Listing> getAllItems()
    {
        var filter = Builders<Listing>.Filter.Empty; // Creates an empty filter to select all documents.
        return collection.Find(filter).ToList(); // Retrieves all listings as a List.
    }

    // Retrieves listings filtered by category, with case-insensitive comparison.
    public List<Listing> SortListingsByCategory(string cname)
    {
        return collection.Find<Listing>(item => item.Category.Equals(cname, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    // Retrieves listings filtered by location, with case-insensitive comparison.
    public List<Listing> SortListingsByLocation(string locationName)
    {
        return collection.Find<Listing>(item => item.Location.Name.Equals(locationName, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    // Retrieves listings by their status, with case-insensitive comparison.
    public List<Listing> SortListingsByStatus(string status)
    {
        return collection.Find<Listing>(item => item.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    // Retrieves listings by user ID.
    public List<Listing> SortListingsByUserId(string userId)
    {
        var filter = Builders<Listing>.Filter.Eq("User.Id", userId); // Filters by User.Id field.
        return collection.Find(filter).ToList();
    }

    // Retrieves listings and sorts them by price in descending order.
    public List<Listing> SortListingByPriceDescending(decimal price)
    {
        return collection.Aggregate().SortByDescending<Listing>(listing => listing.Price).ToList();
    }

    // Retrieves listings and sorts them by price in ascending order.
    public List<Listing> SortListingByPriceAscending(decimal price)
    {
        return collection.Aggregate().SortBy<Listing>(listing => listing.Price).ToList();
    }

    // Deletes a listing from the collection based on its ID.
    public void DeleteListing(string listingId)
    {
        var filter = Builders<Listing>.Filter.Eq("Id", listingId); // Filter to find the document by Id.
        collection.DeleteOne(filter); // Deletes the matching document.
    }

    // Updates a listing document in the collection.
    public void UpdateListing(Listing listing)
    {
        var filter = Builders<Listing>.Filter.Eq("Id", listing.Id); // Filter to find the document by Id.
        var update = Builders<Listing>.Update
            .Set(l => l.Category, listing.Category) // Updates the category.
            .Set(l => l.Title, listing.Title) // Updates the title.
            .Set(l => l.Description, listing.Description) // Updates the description.
            .Set(l => l.Status, listing.Status) // Updates the status.
            .Set(l => l.Price, listing.Price) // Updates the price.
            .Set(l => l.Location, listing.Location); // Updates the location.
        collection.UpdateOne(filter, update); // Applies the update.
    }

}
}