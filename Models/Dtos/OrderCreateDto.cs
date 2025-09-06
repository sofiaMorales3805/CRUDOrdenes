namespace Api.Models.Dtos;
public class OrderCreateDto
{
     public int PersonId { get; set; }
    public string Number { get; set; } = string.Empty;
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public List<OrderDetailCreateDto> OrderDetails { get; set; } = [];
}
