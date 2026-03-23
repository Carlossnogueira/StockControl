using StockControl.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Domain.Entities
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.Employee;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
