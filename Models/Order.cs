namespace Api;

public class Order
{
    public int OrderId { get; set; }
    public required int PersonId { get; set; }
    public Person Person { get; set; }
    public int Number { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<OrderDetail> OrderDetails { get; set; } = [];
}
