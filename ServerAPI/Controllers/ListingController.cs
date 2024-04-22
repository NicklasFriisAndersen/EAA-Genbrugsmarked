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

    }
}

