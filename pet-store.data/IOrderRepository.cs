namespace pet_store.Data;

public interface IOrderRepository
{
    Task AddOrder(Order order);

    Task<Order> GetOrderByIdAsync(int id);
    Task<List<Order>> GetAllOrdersAsync();
}