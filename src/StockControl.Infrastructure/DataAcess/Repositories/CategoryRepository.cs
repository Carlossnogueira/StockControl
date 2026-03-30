using Microsoft.EntityFrameworkCore;
using StockControl.Domain.Entities;
using StockControl.Domain.Repositories;

namespace StockControl.Infrastructure.DataAcess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StockControlContext _context;

        public CategoryRepository(StockControlContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            var result = await _context.Categories.AddAsync(category);
            return result.Entity;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
