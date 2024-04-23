using System;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Controllers;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private IUserRepository uRepo;

        public UserController(IUserRepository repo)
		{
            uRepo = repo;
        }

        [HttpPost]
        [Route("add")]
        public void insertOneUser(User user)
        {
            uRepo.insertOneUser(user);
        }
    }
}

