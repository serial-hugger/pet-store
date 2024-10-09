namespace pet_store.Data;

public interface IProductRepository
{
    void AddProduct(Product product);

    Product GetProductById(int id);
    List<Product> GetProducts();
}