using pet_store.Data;

namespace pet_store;

public interface IProductLogic
{
    public Task AddProductAsync(Product product);
    public Task<List<Product>> GetAllProductsAsync();
    public Task<Product> GetProductByNameAsync(string name);
    public Task<Product> GetProductByIdAsync(int id);
    public Task AddOrderAsync(Order order);
    public Task<List<Order>> GetAllOrdersAsync();
    public Task<Order> GetOrderByIdAsync(int id);
}