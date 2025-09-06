namespace Api.Models.Dtos;

public class OrderReadDto
{
    public int OrderId { get; set; }
    public string Number { get; set; } = string.Empty;
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public PersonReadDto? Person { get; set; }
    public List<OrderDetailReadDto> OrderDetails { get; set; } = [];
}
