using System;
using System.Collections.Generic;
using System.Linq;
using pet_store.Data;

namespace pet_store;

public class OrderLogic : IOrderLogic
{
    private readonly IOrderRepository _repository;
    public OrderLogic(IOrderRepository repository)
    {
        _repository = repository;
    }
    public void AddOrder(Order order)
    {
        _repository.AddOrder(order);
    }

    public List<Order> GetAllOrders()
    {
        return _repository.GetOrders();
    }

    public Order GetOrderById(int id)
    {
        try
        {
            return _repository.GetOrders().Where(p => p.OrderId == id).First();
        }
        catch (Exception)
        {
            return null;
        }
    }
}