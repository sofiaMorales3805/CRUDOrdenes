namespace Api.Models.Dtos;

public class OrderDetailCreateDto
{
    public int ItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }   // 👈 corresponde al campo Price de OrderDetail
    public decimal Total { get; set; }   // 👈 corresponde al campo Total
}
