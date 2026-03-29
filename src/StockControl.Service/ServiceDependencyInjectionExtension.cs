using Microsoft.Extensions.DependencyInjection;
using StockControl.Domain.Service;
using StockControl.Service.Category;
using StockControl.Service.Login;
using StockControl.Service.User;


namespace StockControl.Service
{
    public static class ServiceDependencyInjectionExtension
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IItemService, Item.ItemService>();
        }
    }
}
