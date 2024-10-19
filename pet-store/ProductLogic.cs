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
        _productRepo.AddProduct(product);
    }
    public List<Product> GetAllProducts()
    {
        return _productRepo.GetAllProducts();
    }
    public Product GetProductById(int id)
    {
        return _productRepo.GetProductById(id);
    }
    public Product GetProductByName(string name)
    {
        try
        {
            return _productRepo.GetAllProducts().Where(p => p.Name == name).First();
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
        return _orderRepo.GetAllOrders();
    }
    public Order GetOrderById(int id)
    {
        return _orderRepo.GetOrderById(id);
    }
}