using StockControl.Domain.Entities;


namespace StockControl.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByLoginAsync(string name);
        void UpdateUserAsync(User user);
    }
}
