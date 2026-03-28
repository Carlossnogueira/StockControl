using Microsoft.EntityFrameworkCore;
using StockControl.Domain.Entities;

namespace StockControl.Infrastructure.DataAcess
{
    public class StockControlContext : DbContext
    {
        
        public StockControlContext(DbContextOptions<StockControlContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Login)
                .IsUnique();

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.User)
                .WithMany(u => u.Items)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
