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

    public void AddProduct(Product product)
    {
        _productRepo.AddProductAsync(product);
    }
    public List<Product> GetAllProducts()
    {
        var products = _productRepo.GetAllProductsAsync().Result;
        return products;
    }
    public Product GetProductById(int id)
    {
        var product = _productRepo.GetProductByIdAsync(id).Result;
        return product;
    }
    public Product GetProductByName(string name)
    {
        try
        {
            var products = _productRepo.GetAllProductsAsync().Result;
            return products.Where(p => p.Name == name).First();
        }
        catch (Exception)
        {
            return null;
        }
    }
    public void AddOrder(Order order)
    {
        _orderRepo.AddOrder(order);
    }
    public List<Order> GetAllOrders()
    {
        var orders = _orderRepo.GetAllOrdersAsync().Result;
        return orders;
    }
    public Order GetOrderById(int id)
    {
        var order = _orderRepo.GetOrderByIdAsync(id).Result;
        return order;
    }
}