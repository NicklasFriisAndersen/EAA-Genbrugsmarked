using System;
using Core.Models;

namespace ServerAPI.Repositories
{
	public interface IUserRepository
	{
        public void insertOneUser(User user);
    }
}

