using StockControl.Communication.Request.Item;
using StockControl.Communication.Response.Item;

namespace StockControl.Domain.Service
{
    public interface IItemService
    {
        Task<CreateItemResponse> CreateItemAsync(int userId, CreateItemDto item);
        Task<List<ItemListResponse>> GetAllAsync();
        Task<ItemListResponse> GetByIdAsync(int id);
        Task<ItemListResponse> GetByNameAsync(string name);
        Task<CreateItemResponse> UpdateItem(int id, UpdateItemDto item);
    }
}