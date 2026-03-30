using StockControl.Communication.Request.Catogory;
using StockControl.Communication.Response.Category;
using StockControl.Domain.Entities;


namespace StockControl.Domain.Service
{
    public interface ICategoryService
    {
        public Task<Category> CreateCategoryAsync(int userId, CreateCategoryDto categoryDto);
        public Task<List<CategoryResponse>> GetAllAsync();
        public Task<CategoryResponse> GetByIdAsync(int id);
        public Task<CategoryResponse> Update(int id, CreateCategoryDto categoryDto);
        public Task Delete(int id);
    }
}
