using StockControl.Communication.Response.Item;
using StockControl.Domain.Entities;

namespace StockControl.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<Category?> GetByIdAsync(int id);
        Task<Category?> GetByNameAsync(string name);
        Task<List<Category>> GetAllAsync();
        void UpdateCategory(Category category);
    }
}
