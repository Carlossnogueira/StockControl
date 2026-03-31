using Microsoft.EntityFrameworkCore;
using StockControl.Communication.Response.Item;
using StockControl.Domain.Entities;
using StockControl.Domain.Repositories;

namespace StockControl.Infrastructure.DataAcess.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly StockControlContext _context;

        public ItemRepository(StockControlContext context)
        {
            _context = context;
        }

        public async Task<Item> CreateAsync(Item item)
        {
            var result = await _context.Items.AddAsync(item);
            return result.Entity;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<List<ItemListResponse>> GetAllProjectedAsync()
        {
            return await _context.Items .Select(item => new ItemListResponse
            {
                Id = item.Id,
                Name = item.Name,
                SKU = item.SKU,
                Category = item.Category.Name,
                Quantity = item.Quantity,
                Price = item.Price,
                SalePrice = item.SalePrice,
                Supplier = item.Supplier,
                CreatedAt = item.CreatedAt,
                Status = item.Status.ToString(),
                CreatedBy = item.User.Name,
                Description = item.Description
            })
          .ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _context.Items
                .Include(i => i.Category)
                .Include(i => i.User)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Item?> GetByNameAsync(string name)
        {
            return await _context.Items
                .Include(i => i.Category)
                .Include(i => i.User)
                .FirstOrDefaultAsync(i => i.Name == name);
        }

        public void UpdateItem(Item item)
        {
            _context.Items.Update(item);
        }
    }
}
