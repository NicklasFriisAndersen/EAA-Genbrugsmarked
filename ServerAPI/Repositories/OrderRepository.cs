using System;
using Core.Models;
using MongoDB.Driver;

namespace ServerAPI.Repositories
{
	public class OrderRepository : IOrderRepository
	{
	private string connectionString = "mongodb+srv://gruppe3mini:gruppe3projekt@genbrugshjemmeside.l92667j.mongodb.net/?retryWrites=true&w=majority&appName=Genbrugshjemmeside";

	IMongoClient mongoClient;

	IMongoDatabase database;

	IMongoCollection<Order> collection;

	
	public OrderRepository()
	{
		mongoClient = new MongoClient(connectionString);

		database = mongoClient.GetDatabase("Genbrugsmarked");

		collection = database.GetCollection<Order>("Order");
	}

	public void insertOneOrder(Order order)
	{
		collection.InsertOne(order);
	}
	
	public List<Order> getAllOrders()
	{
		var filter = Builders<Order>.Filter.Empty;

		return collection.Find(filter).ToList();
	}
	}
}

