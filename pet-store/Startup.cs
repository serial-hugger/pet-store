using pet_store.Data;

namespace pet_store;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
            services.AddControllers();
            services.AddTransient<IProductLogic,ProductLogic>();
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}