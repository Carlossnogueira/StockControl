using Microsoft.Extensions.DependencyInjection;
using StockControl.Domain.Service;
using StockControl.Service.User;


namespace StockControl.Service
{
    public static class ServiceDependencyInjectionExtension
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
