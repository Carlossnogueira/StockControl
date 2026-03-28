using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Item?>> GetAllAsync()
        {
            var result = await _context.Items.ToListAsync();
            return result;
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<Item?> GetByNameAsync(string name)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.Name == name);
        }

        public void UpdateItemAsync(Item item)
        {
            _context.Items.Update(item);
        }
    }
}
