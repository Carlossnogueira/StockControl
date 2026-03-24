using Microsoft.EntityFrameworkCore;
using StockControl.Domain.Entities;
using StockControl.Domain.Repositories;


namespace StockControl.Infrastructure.DataAcess.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly StockControlContext _context;

        public UserRepository(StockControlContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            var createdUser = await _context.Users.AddAsync(user);
            return createdUser.Entity;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<User?> GetByNameAsync(string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
            return user;
        }

        public void UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
