namespace pet_store.Data;

public interface IProductRepository
{
    Task AddProductAsync(Product product);

    Task<Product> GetProductByIdAsync(int id);
    Task<List<Product>> GetAllProductsAsync();
}