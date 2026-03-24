using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockControl.Domain;
using StockControl.Domain.Repositories;
using StockControl.Infrastructure.DataAcess;
using StockControl.Infrastructure.DataAcess.Repositories;
using StockControl.Infrastructure.Security;

namespace StockControl.Infrastructure
{
    public static class InfrastructureDependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Dbcontext
            services.AddDbContext<StockControlContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IPasswordEncrypter, PasswordEncrypter>();

            AddRepositories(services);
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}