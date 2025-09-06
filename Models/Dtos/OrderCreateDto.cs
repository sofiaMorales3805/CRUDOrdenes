namespace Api.Models.Dtos;
public class OrderCreateDto
{
    public int PersonId { get; set; }
    public string Number { get; set; }
    public int CreatedBy { get; set; } = string.Empty;
    public int? UpdatedBy { get; set; }
    public List<OrderDetailCreateDto> OrderDetails { get; set; } = [];
}
