using System.Collections.Generic;

namespace pet_store;

public interface IProductLogic
{
    public void AddProduct(Product product);
    public List<Product> GetAllProducts();
    public Product GetProductByName(string name);
}