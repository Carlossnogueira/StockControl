using StockControl.Communication.Request.User;
using StockControl.Domain.Entities;

namespace StockControl.Domain.Service
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(CreateUserDto userDto);
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetbyName(string name);
    }
}
