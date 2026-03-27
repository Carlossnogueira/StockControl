using StockControl.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? SKU { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }

        public string? Supplier { get; set; }
        public ItemStatus Status { get; set; } = ItemStatus.Active;
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public string? Description { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
