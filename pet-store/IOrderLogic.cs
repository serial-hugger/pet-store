using System.Collections.Generic;
using pet_store.Data;

namespace pet_store;

public interface IOrderLogic
{
    public void AddOrder(Order order);
    public List<Order> GetAllOrders();
    public Order GetOrderById(int id);
}