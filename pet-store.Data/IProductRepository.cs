namespace pet_store.Data;

public interface IProductRepository
{
    void AddProduct(Product product);

    Product GetProduct(int id);
    List<Product> GetProducts();
}