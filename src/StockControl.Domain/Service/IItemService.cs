using StockControl.Communication.Request.Item;
using StockControl.Communication.Response.Item;
using StockControl.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockControl.Domain.Service
{
    public interface IItemService
    {
        Task<CreateItemResponse> CreateItemAsync(int userId, CreateItemDto item);
        Task<List<ItemListResponse>> GetAllAsync();
        Task<CreateItemResponse?> GetByIdAsync(int id);
        Task<CreateItemResponse?> GetByNameAsync(string name);
        Task UpdateItemAsync(CreateItemDto item);
    }
}