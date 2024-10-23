using Microsoft.EntityFrameworkCore;

namespace pet_store.Data;

public class OrderRepository : IOrderRepository
{
    private readonly DbContext _context;
    public OrderRepository()
    {
        _context = new DbContext();
    }

    public async Task AddOrder(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await _context.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders.ToListAsync();
    }
}