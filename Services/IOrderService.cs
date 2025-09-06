using Api.Models.Dtos;

namespace Api.Services;

public interface IOrderService
{
    Task<IEnumerable<OrderReadDto>> GetAllOrdersAsync();
    Task<OrderReadDto> CreateOrderAsync(OrderCreateDto dto);
    Task<bool> DeleteOrderAsync(int id);
}
