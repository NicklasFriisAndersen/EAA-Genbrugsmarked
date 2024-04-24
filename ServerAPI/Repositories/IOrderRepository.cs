using Core.Models;

namespace ServerAPI.Repositories;

public interface IOrderRepository
{
    public void insertOneOrder(Order order);
    
    public List<Order> getAllOrders();
}