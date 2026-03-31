using System;
using StockControl.Communication.Enum;

namespace StockControl.Communication.Request.Item;

public class UpdateItemDto
{
    public string? Name { get; set; }
    public string? SKU { get; set; }
    public int CategoryId { get; set; }
    public int? Quantity { get; set; }
    public decimal? Price { get; set; }
    public decimal? SalePrice { get; set; }
    public string? Supplier { get; set; }
    public ItemStatus? Status { get; set; }
    public string? Description { get; set; }
}