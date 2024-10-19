using pet_store;

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
}