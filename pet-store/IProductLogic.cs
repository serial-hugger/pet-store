using System.Collections.Generic;

namespace pet_store;

public interface IProductLogic
{
    public void AddProduct(Product product);
    public List<Product> GetAllProducts();
    public T GetProductByName<T>(string name) where T: Product;

    public List<Product> GetOnlyInStockProducts();
    public decimal GetTotalPriceOfProducts();
}