using System;
using Core.Models;

namespace ServerAPI.Repositories
{
	public interface IListingRepository
	{

        public void insertOneListing(Listing listing);

        public List<Listing> getAllItems();

        public List<Listing> SortListingsByCategory(string cname);
	}
}

