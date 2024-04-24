using System;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;
using Core.Models;

namespace ServerAPI.Controllers
{
	[ApiController]
	[Route("api/order")]
	public class OrderController : ControllerBase
	{
	private IOrderRepository _orderRepository;

	public OrderController(IOrderRepository orderRepository)
	{
		_orderRepository = orderRepository;
	}

	[HttpPost]
	[Route("add")]
	public void insertOneOrder(Order order)
	{
		_orderRepository.insertOneOrder(order);
	}
	
	[HttpGet]
	[Route("getall")]
	public IEnumerable<Order> GetAll()
	{
		return _orderRepository.getAllOrders();
	}
	}
}

