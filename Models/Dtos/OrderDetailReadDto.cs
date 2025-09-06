namespace Api.Models.Dtos;

public class OrderDetailReadDto
{
    public int OrderDetailId { get; set; }   // ID del detalle
    public int ItemId { get; set; }          // FK del item
    public string ItemName { get; set; }  = string.Empty;    // Nombre del item (opcional, útil para mostrar en frontend)
    public int Quantity { get; set; }        // Cantidad del item
    public decimal Price { get; set; }   
    public decimal Total { get; set; }   
}
