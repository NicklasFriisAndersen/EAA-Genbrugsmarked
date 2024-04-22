using System;
using Core.Models;
using MongoDB.Bson;

namespace ServerAPI.Repositories

{
	public class UserRepository
	{
		private User testuser = new User()
		{
			//UserID = "1",
			Username = "testbruger1",
			Password = "1234567",
			Email = "test@gmail.com",
			Role = "",
			Orders = new List<Order>(),
			Listings = new List<Listing>()
		};
	}
	

}

