using System;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Controllers;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers
{
    [ApiController]
    [Route("api/listing")]
    public class ListingController : ControllerBase
    {
        private IListingRepository lRepo;

        public ListingController(IListingRepository repo)
        {
            lRepo = repo;
        }

        [HttpPost]
        [Route("add")]
        public void insertOneListing(Listing listing)
        {
            lRepo.insertOneListing(listing);
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<Listing> GetAll()
        {
            return lRepo.getAllItems();
        }

        [HttpGet]
        [Route("getbyfilter")]
        public IEnumerable<Listing> GetAll([FromQuery] string category)
        {
            return lRepo.SortListingsByCategory(category);
        }

        [HttpGet]
        [Route("getbyuserid")]
        public IEnumerable<Listing> GetAllByUserId([FromQuery] string userId)
        {
            return lRepo.SortListingsByUserId(userId);
        }

        [HttpDelete]
        [Route("deletebyid")]
        public void DeleteGetAllListingId([FromQuery] string listingId)
        {
             lRepo.DeleteListing(listingId);
        }

    }
}