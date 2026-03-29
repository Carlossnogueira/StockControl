using System;

namespace StockControl.Communication.Response.Item;

public class CreateItemResponse
{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? SKU { get; set; }
        public string Category { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public string? Supplier { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Description { get; set; } 
}
