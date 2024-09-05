using System.Collections.Generic;

namespace pet_store;

public interface IProductLogic
{
    public void AddProduct(Product product);
    public List<Product> GetAllProducts();
    public CatFood GetCatFoodByName(string name);
    public DogLeash GetDogLeashByName(string name);

    public List<Product> GetOnlyInStockProducts();
    public decimal GetTotalPriceOfProducts();
}