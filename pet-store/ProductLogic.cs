using System.Collections.Generic;
using System;
using System.Linq;

namespace pet_store;

public class ProductLogic : IProductLogic
{
    private List<Product> _products = new List<Product>()
    {
        new DryCatFood(){Name="Friskies",IsKittenFood = false,WeightPounds = 20,Price = (decimal)19.99,Quantity = 21},
        new DryCatFood(){Name="9 Lives",IsKittenFood = false,WeightPounds = 20,Price = (decimal)19.99,Quantity = 0},
        new DryCatFood(){Name="Meow Mix",IsKittenFood = false,WeightPounds = 20,Price = (decimal)19.99,Quantity = 1}
    };

    private Dictionary<string, CatFood> _catFoods = new Dictionary<string, CatFood>();
    private Dictionary<string, DogLeash> _dogLeashes = new Dictionary<string, DogLeash>();

    public void AddProduct(Product product)
    {
        _products.Add(product);
        if (product is CatFood)
        {
            _catFoods.Add(product.Name,product as CatFood);
        }
        if (product is DogLeash)
        {
            _dogLeashes.Add(product.Name,product as DogLeash);
        }
    }

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    public CatFood GetCatFoodByName(string name)
    {
        try
        {
            return _catFoods[name];
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public DogLeash GetDogLeashByName(string name)
    {
        try
        {
            return _dogLeashes[name];
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public List<Product> GetOnlyInStockProducts()
    {
        return _products.InStock();
    }
    public decimal GetTotalPriceOfProducts()
    {
        return _products.GetTotalPriceOfInventory();
    }
}