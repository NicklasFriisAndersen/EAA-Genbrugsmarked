using System;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Controllers;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers
{
    [ApiController]  // Specifies that this class is a controller with API capabilities.
    [Route("api/listing")]  // Defines the base route for this controller.
    public class ListingController : ControllerBase
    {
        private IListingRepository lRepo;  // Declaration of a repository interface to interact with listings.

        // Constructor to inject the repository dependency for accessing listing data.
        public ListingController(IListingRepository repo)
        {
            lRepo = repo;
        }

        [HttpPost]  // HTTP POST method attribute.
        [Route("add")]  // Defines the route for adding a new listing.
        public void insertOneListing(Listing listing)
        {
            lRepo.insertOneListing(listing);  // Calls the repository method to add a new listing.
        }

        [HttpGet]  // HTTP GET method attribute.
        [Route("getall")]  // Route for retrieving all listings.
        public IEnumerable<Listing> GetAll()
        {
            return lRepo.getAllItems();  // Retrieves all listings from the repository.
        }

        [HttpGet]
        [Route("getbyfilter")]  // Route for retrieving listings by a category filter.
        public IEnumerable<Listing> GetAll([FromQuery] string category)
        {
            return lRepo.SortListingsByCategory(category);  // Retrieves listings filtered by category.
        }

        [HttpGet]
        [Route("getbylocation")]  // Route for retrieving listings by location.
        public IEnumerable<Listing> GetAllFromLocation([FromQuery] string location)
        {
            return lRepo.SortListingsByLocation(location);  // Retrieves listings filtered by location.
        }

        [HttpGet]
        [Route("getbyuserid")]  // Route for retrieving listings by a user's ID.
        public IEnumerable<Listing> GetAllByUserId([FromQuery] string userId)
        {
            return lRepo.SortListingsByUserId(userId);  // Retrieves listings associated with a specific user.
        }

        [HttpDelete]  // HTTP DELETE method attribute.
        [Route("deletebyid")]  // Route for deleting a listing by ID.
        public void DeleteGetAllListingId([FromQuery] string listingId)
        {
            lRepo.DeleteListing(listingId);  // Calls the repository method to delete a listing.
        }

        [HttpGet]
        [Route("getbypricedescending")]  // Route for retrieving listings sorted by price in descending order.
        public IEnumerable<Listing> GetAllByPriceDescending([FromQuery] decimal price)
        {
            return lRepo.SortListingByPriceDescending(price);  // Retrieves listings sorted by price, highest to lowest.
        }

        [HttpGet]
        [Route("getbypriceascending")]  // Route for retrieving listings sorted by price in ascending order.
        public IEnumerable<Listing> GetAllByPriceAscending([FromQuery] decimal price)
        {
            return lRepo.SortListingByPriceAscending(price);  // Retrieves listings sorted by price, lowest to highest.
        }

        [HttpPost]  // HTTP POST method for updates.
        [Route("update")]  // Route for updating a listing.
        public void UpdateOne(Listing listing)
        {
            lRepo.UpdateListing(listing);  // Calls the repository method to update a listing.
        }

        [HttpGet]
        [Route("getbystatus")]  // Route for retrieving listings by status.
        public IEnumerable<Listing> GetByStatus([FromQuery] string status)
        {
            return lRepo.SortListingsByStatus(status);  // Retrieves listings filtered by their status.
        }

    }
}
