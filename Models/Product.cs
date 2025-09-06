using Api.Models; // Para los modelos

namespace Api.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<OrderDetail> OrderDetails { get; set; } = [];
}
