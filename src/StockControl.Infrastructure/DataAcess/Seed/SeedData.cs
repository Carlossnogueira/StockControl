using Microsoft.Extensions.DependencyInjection;
using StockControl.Domain.Entities;
using StockControl.Domain.Enum;
using StockControl.Domain.Security;


namespace StockControl.Infrastructure.DataAcess.Seed
{
    public static class SeedData
    {
        public static async Task SeedAdminAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<StockControlContext>();
            var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordEncrypter>();

            if (!context.Users.Any(u => u.Login == "admin"))
            {
                var admin = new User
                {
                    Name = "Admin",
                    Login = "admin",
                    Password = passwordHasher.EncryptPassword("12345678"),
                    Role = Role.Manager,
                    CreatedAt = DateTime.UtcNow
                };

                context.Users.Add(admin);
                await context.SaveChangesAsync();
            }
        }
    }
}
