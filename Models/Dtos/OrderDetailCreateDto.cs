namespace Api.Models.Dtos;

public class OrderDetailCreateDto
{
    public int OrderDetailId { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Total => Quantity * UnitPrice;
}
