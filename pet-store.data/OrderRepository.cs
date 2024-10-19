namespace pet_store.Data;

public class OrderRepository : IOrderRepository
{
    private readonly DbContext _context;
    public OrderRepository()
    {
        _context = new DbContext();
    }

    public void AddOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }

    public Order GetOrderById(int id)
    {
        return _context.Orders.Where(o => o.OrderId == id).FirstOrDefault();
    }

    public List<Order> GetAllOrders()
    {
        return _context.Orders.ToList();
    }
}