using System.Collections.Generic;
using System;

namespace pet_store;

public class ProductLogic
{
    private List<Product> _products = new List<Product>();

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
}