using System;
using System.Net.Security;
using System.Text.Json;
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
    private static ProductLogic productLogic { get; set; } = new ProductLogic();
    private static UILogic uiLogic { get; set; } = new UILogic();

    public static void Main(String[] args)
    {
        string userInput = "";
        while (userInput.ToLower() != "exit")
        {
            userInput = uiLogic.OptionSelect();
            if (userInput=="1")
            {
                userInput = uiLogic.Ask("What kind of product? (catfood, dogleash)");
                if (userInput.ToLower().Contains("catfood"))
                {
                    userInput=uiLogic.Ask("Is it dry food?");
                    var catFood = new CatFood();
                    if (userInput.Contains("yes")||userInput.Contains("true"))
                    {
                        catFood = new DryCatFood();
                    }

                    //Get Name
                    userInput=uiLogic.Ask("Name?");
                    catFood.Name = userInput;
                    //Get Description
                    userInput = uiLogic.Ask("Description?");
                    catFood.Description = userInput;
                    //Get Whether Kitten Food
                    userInput = uiLogic.Ask("Kitten food? (yes, no)");
                    if (userInput.Contains("yes") || userInput.Contains("true"))
                    {
                        catFood.IsKittenFood = true;
                    }
                    else
                    {
                        catFood.IsKittenFood = false;
                    }

                    //Get Price
                    userInput = uiLogic.Ask("Price?");
                    try
                    {
                        catFood.Price = Decimal.Parse(userInput);
                    }
                    catch
                    {
                        catFood.Price = (decimal)0.00;
                    }

                    //Get Quantity
                    userInput = uiLogic.Ask("Quantity?");
                    try
                    {
                        catFood.Quantity = int.Parse(userInput);
                    }
                    catch
                    {
                        catFood.Quantity = 0;
                    }

                    if (catFood is DryCatFood)
                    {
                        //Get Weight
                        userInput = uiLogic.Ask("Weight in pounds?");
                        try
                        {
                            (catFood as DryCatFood).WeightPounds = double.Parse(userInput);
                        }
                        catch
                        {
                            (catFood as DryCatFood).WeightPounds = 0.0;
                        }
                    }

                    if (catFood is DryCatFood)
                    {
                        productLogic.AddProduct(catFood as DryCatFood);
                    }
                    else
                    {
                        productLogic.AddProduct(catFood as CatFood);
                    }

                    uiLogic.Say("Product Added!");
                }
                else if (userInput.ToLower().Contains("dogleash"))
                {
                    var dogLeash = new DogLeash();
                    //Get Name
                    userInput=uiLogic.Ask("Name?");
                    dogLeash.Name = userInput;
                    //Get Description
                    userInput = uiLogic.Ask("Description?");
                    dogLeash.Description = userInput;
                    //Get Price
                    userInput = uiLogic.Ask("Price?");
                    try
                    {
                        dogLeash.Price = Decimal.Parse(userInput);
                    }
                    catch
                    {
                        dogLeash.Price = (decimal)0.00;
                    }

                    //Get Quantity
                    userInput = uiLogic.Ask("Quantity?");
                    try
                    {
                        dogLeash.Quantity = int.Parse(userInput);
                    }
                    catch
                    {
                        dogLeash.Quantity = 0;
                    }

                    //Get Length in inches
                    userInput = uiLogic.Ask("Length in inches?");
                    try
                    {
                        dogLeash.LengthInches = int.Parse(userInput);
                    }
                    catch
                    {
                        dogLeash.LengthInches = 0;
                    }
                    //Get Material
                    userInput = uiLogic.Ask("Material?");
                    dogLeash.Material = userInput;
                    productLogic.AddProduct(dogLeash);
                    uiLogic.Say("Product Added!");
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
}