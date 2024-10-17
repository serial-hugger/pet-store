using pet_store;
using pet_store.Data;
public partial class Program
{
    //{ "Price": 58.89, "Name": "Special dog leash", "Quantity": 23, "Description": "Magical leash that will help your dog not pull hard when going on walks"}
    static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    /*public static void Main(String[] args)
    {
        var productLogic = services.GetService<IProductLogic>();
        var orderLogic = services.GetService<IOrderLogic>();
        string userInput = "";
        while (userInput.ToLower() != "exit")
        {
            userInput = uiLogic.OptionSelect();
            if (userInput=="1")
            {
                userInput = uiLogic.Ask("Enter the product json.");
                productLogic.AddProduct(JsonSerializer.Deserialize<Product>(userInput));
            }
            if (userInput=="2")
            {
                userInput = uiLogic.Ask("What is the name of the product?");
                Product product = productLogic.GetProductByName(userInput);
                if (product != null)
                {
                    uiLogic.Say(JsonSerializer.Serialize(product));
                }
                else
                {
                    uiLogic.Say("No product with that name!");
                }
            }
            if (userInput=="3")
            {
                userInput = uiLogic.Ask("Enter the order json.");
                orderLogic.AddOrder(JsonSerializer.Deserialize<Order>(userInput));
            }
            if (userInput=="4")
            {
                userInput = uiLogic.Ask("What is the id of the order?");
                Order order = orderLogic.GetOrderById(int.Parse(userInput));
                if (order != null)
                {
                    uiLogic.Say(JsonSerializer.Serialize(order));
                }
                else
                {
                    uiLogic.Say("No order with that id!");
                }
            }
        }
    }*/


}