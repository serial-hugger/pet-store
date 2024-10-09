using System.Collections.Generic;
using System;
using System.Linq;
using FluentValidation;
using Microsoft.Extensions.Options;
using pet_store.Data;
using pet_store.Validators;

namespace pet_store;

public class ProductLogic : IProductLogic
{
    private readonly IProductRepository _repository;
    public ProductLogic(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public void AddProduct(Product product)
    {
        _repository.AddProduct(product);
    }

    public List<Product> GetAllProducts()
    {
        return _repository.GetProducts();
    }

    public Product GetProductById(int id)
    {
        return _repository.GetProductById(id);
    }
    public Product GetProductByName(string name)
    {
        try
        {
            return _repository.GetProducts().Where(p => p.Name == name).First();
        }
        catch (Exception)
        {
            return null;
        }
    }
}