using StockControl.Domain.Entities;


namespace StockControl.Domain.Repository
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByNameAsync(string name);
        void UpdateUserAsync(User user);
    }
}
