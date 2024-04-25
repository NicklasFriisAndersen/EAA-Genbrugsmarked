using System;
using Core.Models;

namespace ServerAPI.Repositories
{
    public interface IListingRepository
    {
                // Method to insert a single listing into the database.
        public void insertOneListing(Listing listing);

               // Method to retrieve all listings from the database.
        public List<Listing> getAllItems();
            
               // Method to retrieve listings filtered by a specific category.
        public List<Listing> SortListingsByCategory(string cname);

                // Method to retrieve listings based on their location.
        public List<Listing> SortListingsByLocation(string locationName);

                // Method to retrieve listings associated with a specific user ID.
        public List<Listing> SortListingsByUserId(string userId);

                // Method to retrieve listings sorted by price in descending order.
        public List<Listing> SortListingByPriceDescending(decimal price);

                // Method to retrieve listings sorted by price in ascending order.
        public List<Listing> SortListingByPriceAscending(decimal price);

                // Method to delete a specific listing by its ID.
        public void DeleteListing(string listingId);

                // Method to update details of an existing listing.
        public void UpdateListing(Listing listing);

                // Method to retrieve listings filtered by a specific status.
        public List<Listing> SortListingsByStatus(string status);
    }
}

