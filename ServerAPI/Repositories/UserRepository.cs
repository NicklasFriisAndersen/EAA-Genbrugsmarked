using System;
using Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ServerAPI.Repositories

{
	public class UserRepository : IUserRepository
    {
        private string connectionString = "mongodb+srv://gruppe3mini:gruppe3projekt@genbrugshjemmeside.l92667j.mongodb.net/?retryWrites=true&w=majority&appName=Genbrugshjemmeside";

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<User> collection;


        public UserRepository()
        {
            mongoClient = new MongoClient(connectionString);

            database = mongoClient.GetDatabase("Genbrugsmarked");

            collection = database.GetCollection<User>("User");
        }

        public void insertOneUser(User user)
        {
            collection.InsertOne(user);
        }
    }
	

	 
}

