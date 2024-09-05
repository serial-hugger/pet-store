using System;
using System.Net.Security;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using pet_store;

/*
    1. Encapsulation is important because it helps prevent errors from data accidentally being modified in a class.
    2. Abstraction could be used to have an error logging system.
    3. Now asks if catfood is dry.
    4. Add product uses polymorphism by accepting DogLeash and CatFood class as their base class Product for the
    input and then does different actions depending on the derived class.
 */

public partial class Program
{
    static IServiceProvider services = CreateServiceCollection();
    private static UILogic uiLogic { get; set; } = new UILogic();

    public static void Main(String[] args)
    {
        var productLogic = services.GetService<IProductLogic>();
        string userInput = "";
        while (userInput.ToLower() != "exit")
        {
            userInput = uiLogic.OptionSelect();
            if (userInput=="1")
            {
                userInput = uiLogic.Ask("What kind of product? (catfood, dogleash)");
                if (userInput.ToLower().Contains("catfood"))
                {
                    userInput = uiLogic.Ask("Enter JSON");
                    productLogic.AddProduct(JsonSerializer.Deserialize<CatFood>(userInput));
                }
                if (userInput.ToLower().Contains("dogleash"))
                {
                    userInput = uiLogic.Ask("Enter JSON");
                    productLogic.AddProduct(JsonSerializer.Deserialize<DogLeash>(userInput));
                }
            }

            if (userInput=="2")
            {
                userInput = uiLogic.Ask("What is the name of the product?");
                CatFood catFood = productLogic.GetCatFoodByName(userInput);
                DogLeash dogLeash = productLogic.GetDogLeashByName(userInput);
                if (catFood!=null)
                {
                    if (catFood is DryCatFood)
                    {
                        uiLogic.Say(JsonSerializer.Serialize(catFood as DryCatFood));
                    }
                    else
                    {
                        uiLogic.Say(JsonSerializer.Serialize(catFood));
                    }
                }
                else if (dogLeash!=null)
                {
                    uiLogic.Say(JsonSerializer.Serialize(catFood));
                }
                else
                {
                    uiLogic.Say("No product with that name!");
                }
            }

            if (userInput=="3")
            {
                foreach (var name in productLogic.GetOnlyInStockProducts())
                {
                    uiLogic.Say(name.Name);
                }
            }
            if (userInput=="4")
            {
                uiLogic.Say(productLogic.GetTotalPriceOfProducts().ToString());
            }
        }
    }

    static IServiceProvider CreateServiceCollection()
    {
        return new ServiceCollection()
            .AddTransient<IProductLogic,ProductLogic>()
            .BuildServiceProvider();
    }
}