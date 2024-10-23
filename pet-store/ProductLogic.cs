using pet_store.Data;

namespace pet_store;

public class ProductLogic : IProductLogic
{
    private readonly IProductRepository _productRepo;
    private readonly IOrderRepository _orderRepo;
    public ProductLogic(IProductRepository productRepo, IOrderRepository orderRepo)
    {
        _productRepo = productRepo;
        _orderRepo = orderRepo;
    }

    public async Task AddProductAsync(Product product)
    {
        await _productRepo.AddProductAsync(product);
    }
    public async Task<List<Product>> GetAllProductsAsync()
    {
        var products = await _productRepo.GetAllProductsAsync();
        return products;
    }
    public async Task<Product> GetProductByIdAsync(int id)
    {
        var product = await _productRepo.GetProductByIdAsync(id);
        return product;
    }
    public async Task<Product> GetProductByNameAsync(string name)
    {
        try
        {
            var products = await _productRepo.GetAllProductsAsync();
            return products.Where(p => p.Name == name).First();
        }
        catch (Exception)
        {
            return null;
        }
    }
    public async Task AddOrderAsync(Order order)
    {
        await _orderRepo.AddOrder(order);
    }
    public async Task<List<Order>> GetAllOrdersAsync()
    {
        var orders = await _orderRepo.GetAllOrdersAsync();
        return orders;
    }
    public async Task<Order> GetOrderByIdAsync(int id)
    {
        var order = await _orderRepo.GetOrderByIdAsync(id);
        return order;
    }
}