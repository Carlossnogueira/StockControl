using StockControl.Communication.Response.Item;
using StockControl.Domain.Entities;

namespace StockControl.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<Item> CreateAsync(Item item);
        Task<Item?> GetByIdAsync(int id);
        Task<Item?> GetByNameAsync(string name);
        Task<List<Item>> GetAllAsync();
        void UpdateItemAsync(Item item);
        Task<List<ItemListResponse>> GetAllProjectedAsync();
    }
}
