using System;
using Core.Models;

namespace ServerAPI.Repositories
{
	public interface IListingRepository
	{

        public void insertOneListing(Listing listing);

        public List<Listing> getAllItems();

        public List<Listing> SortListingsByCategory(string cname);

        public List<Listing> SortListingsByLocation(string locationName);

        public List<Listing> SortListingsByUserId(string userId);

        public void DeleteListing(string listingId);

        public void UpdateListing (Listing listing);

	}
}

