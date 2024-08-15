using MTW.Plugins.InMemory;
using MTW.UseCases.Inventories;
using MTW.UseCases.Inventories.Interfaces;
using MTW.UseCases.PluginInterfaces;
using MTW.UseCases.Products;
using MTW.UseCases.Products.Interfaces;
using MTW.WebApp.Components;

namespace MTW.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents();
            builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
            builder.Services.AddTransient<IViewInventoriesByNameUseCases, ViewProductsByNameUseCases>();
            builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();
            builder.Services.AddTransient<IEditInventoryUseCase, EditInventoryUseCase>();
            builder.Services.AddTransient<IDeleteInventoryUseCase,  DeleteInventoryUseCase>();

            builder.Services.AddTransient<IViewProductByNameUseCase, ViewProductByNameUseCase>();
            builder.Services.AddTransient<IProductRepository, ProductRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>();

            app.Run();
        }
    }
}
