namespace pet_store.Data;

public interface IOrderRepository
{
    void AddOrder(Order order);

    Order GetOrderById(int id);
    List<Order> GetOrders();
}