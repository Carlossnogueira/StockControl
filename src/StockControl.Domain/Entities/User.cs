using StockControl.Domain.Enum;

namespace StockControl.Domain.Entities
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.Employee;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
