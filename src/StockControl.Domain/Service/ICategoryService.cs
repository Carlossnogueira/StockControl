using StockControl.Communication.Request.Catogory;
using StockControl.Communication.Response.Category;
using StockControl.Domain.Entities;


namespace StockControl.Domain.Service
{
    public interface ICategoryService
    {
        public Task<Category> CreateCategoryAsync(int userId, CreateCategoryDto categoryDto);
        public Task<List<CategoryResponse>> GetAllAsync();
    }
}
