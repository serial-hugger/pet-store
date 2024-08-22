using System;
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

    public static void Main(String[] args)
    {
        Console.WriteLine("1: Add product 2: Search product 3: List products in stock");
        Console.WriteLine("Type 'exit' to quit");
        string userInput = Console.ReadLine();
        while (userInput.ToLower() != "exit")
        {
            if (userInput.Contains("1"))
            {
                Console.WriteLine("What kind of product? (catfood, dogleash)");
                userInput = Console.ReadLine();
                if (userInput.ToLower().Contains("catfood"))
                {
                    Console.WriteLine("Is it dry food?");
                    userInput = Console.ReadLine();
                    var catFood = new CatFood();
                    if (userInput.Contains("yes")||userInput.Contains("true"))
                    {
                        catFood = new DryCatFood();
                    }

                    //Get Name
                    Console.WriteLine("Name?");
                    userInput = Console.ReadLine();
                    catFood.Name = userInput;
                    //Get Description
                    Console.WriteLine("Description?");
                    userInput = Console.ReadLine();
                    catFood.Description = userInput;
                    //Get Whether Kitten Food
                    Console.WriteLine("Kitten food? (yes, no)");
                    userInput = Console.ReadLine();
                    if (userInput.Contains("yes") || userInput.Contains("true"))
                    {
                        catFood.IsKittenFood = true;
                    }
                    else
                    {
                        catFood.IsKittenFood = false;
                    }

                    //Get Price
                    Console.WriteLine("Price?");
                    userInput = Console.ReadLine();
                    try
                    {
                        catFood.Price = Decimal.Parse(userInput);
                    }
                    catch
                    {
                        catFood.Price = (decimal)0.00;
                    }

                    //Get Quantity
                    Console.WriteLine("Quantity?");
                    userInput = Console.ReadLine();
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
                        Console.WriteLine("Weight in pounds?");
                        userInput = Console.ReadLine();
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

                    Console.WriteLine("Product Added!");
                }
                else if (userInput.ToLower().Contains("dogleash"))
                {
                    var dogLeash = new DogLeash();
                    //Get Name
                    Console.WriteLine("Name?");
                    userInput = Console.ReadLine();
                    dogLeash.Name = userInput;
                    //Get Description
                    Console.WriteLine("Description?");
                    userInput = Console.ReadLine();
                    dogLeash.Description = userInput;
                    //Get Price
                    Console.WriteLine("Price?");
                    userInput = Console.ReadLine();
                    try
                    {
                        dogLeash.Price = Decimal.Parse(userInput);
                    }
                    catch
                    {
                        dogLeash.Price = (decimal)0.00;
                    }

                    //Get Quantity
                    Console.WriteLine("Quantity?");
                    userInput = Console.ReadLine();
                    try
                    {
                        dogLeash.Quantity = int.Parse(userInput);
                    }
                    catch
                    {
                        dogLeash.Quantity = 0;
                    }

                    //Get Length in inches
                    Console.WriteLine("Length in inches?");
                    userInput = Console.ReadLine();
                    try
                    {
                        dogLeash.LengthInches = int.Parse(userInput);
                    }
                    catch
                    {
                        dogLeash.LengthInches = 0;
                    }

                    //Get Material
                    Console.WriteLine("Material?");
                    userInput = Console.ReadLine();
                    dogLeash.Material = userInput;

                    productLogic.AddProduct(dogLeash);
                    Console.WriteLine("Product Added!");
                }
            }

            if (userInput.Contains("2"))
            {
                Console.WriteLine("What is the name of the product?");
                userInput = Console.ReadLine();

                CatFood catFood = productLogic.GetCatFoodByName(userInput);
                DogLeash dogLeash = productLogic.GetDogLeashByName(userInput);
                if (catFood!=null)
                {
                    if (catFood is DryCatFood)
                    {
                        Console.WriteLine(JsonSerializer.Serialize(catFood as DryCatFood));
                    }
                    else
                    {
                        Console.WriteLine(JsonSerializer.Serialize(catFood));
                    }
                }
                else if (dogLeash!=null)
                {
                    Console.WriteLine(JsonSerializer.Serialize(catFood));
                }
                else
                {
                    Console.WriteLine("No product with that name!");
                }
            }

            if (userInput.Contains("3"))
            {
                foreach (var name in productLogic.GetOnlyInStockProducts())
                {
                    Console.WriteLine(name);
                }
            }

            Console.WriteLine("1: Add product 2: Search product");
            Console.WriteLine("Type 'exit' to quit");
            userInput = Console.ReadLine();
        }
    }
}