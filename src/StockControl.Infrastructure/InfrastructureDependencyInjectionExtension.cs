using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockControl.Domain.Repositories;
using StockControl.Domain.Security;
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

            // Services
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IPasswordEncrypter, PasswordEncrypter>();

            // Repository
            services.AddScoped<IUserRepository, UserRepository>();

            // Token Generator
            var expiretionTimeMinutes = configuration.GetValue<uint>("Jwt:ExpiresMinutes");
            var signingKey = configuration.GetValue<string>("Jwt:SingningKey");

            services.AddScoped<IAcessTokenGenerator>(config => new JwtTokenGenerator(expiretionTimeMinutes, signingKey!));
        }


    }
}