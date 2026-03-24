using Microsoft.EntityFrameworkCore;
using StockControl.Domain.Entities;

namespace StockControl.Infrastructure.DataAcess
{
    public class StockControlContext : DbContext
    {
        DbSet<User> Users { get; set; }
        public StockControlContext(DbContextOptions<StockControlContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Login)
                .IsUnique();
        }
    }
}
