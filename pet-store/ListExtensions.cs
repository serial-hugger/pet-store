using System.Collections.Generic;
using System.Linq;
using pet_store.Data;

namespace pet_store;

static class ListExtensions
{
    public static List<T> InStock<T>(this List<T> list) where T : Product
    {
        return list.Where(x => x.Quantity > 0).Select(x=>x).ToList();
    }
    public static decimal GetTotalPriceOfInventory<T>(this List<T> list) where T : Product
    {
        List<T> productList = list.InStock();
        decimal price = (decimal)0.0;
        foreach (var product in productList)
        {
            price += product.Price * product.Quantity;
        }
        return price;
    }
}