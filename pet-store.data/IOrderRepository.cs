namespace pet_store.Data;

public interface IOrderRepository
{
    void AddOrder(Order order);

    Order GetOrder(int id);
    List<Order> GetOrders();
}