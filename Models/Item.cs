using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

public class Item
{
    public int id { get; set; }
    public required string Name { get; set; }
    [Column(TypeName = "decimal(18,2)")]  // 18 enteros 2 decimales para el precio
    public required decimal precio { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<OrderDetail> OrderDetails { get; set; } = [];
}
