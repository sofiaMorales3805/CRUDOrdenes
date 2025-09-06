using System.Linq;
using Api.Models;
using Api.Models.Dtos;
using Api.Repositories;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;
public class OrderService : IOrderService
{
     private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    // todas las órdenes
    public async Task<IEnumerable<OrderReadDto>> GetAllOrdersAsync()
    {
        var orders = await _context.Orders
            .Include(o => o.Person)
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Item)
            .ToListAsync();

        return orders.Select(o => new OrderReadDto
        {
            OrderId = o.OrderId,
            Number = o.Number,
            CreatedBy = o.CreatedBy,
            CreatedAt = o.CreatedAt,
            UpdatedBy = o.UpdatedBy,
            UpdatedAt = o.UpdatedAt,

            // mapear la persona
            Person = new PersonReadDto {
                PersonId = order.Person.PersonId,
                FirstName = order.Person.FirstName,
                LastName = order.Person.LastName,
                Email = order.Person.Email
            },

            // mapear detalles
            OrderDetails = order.OrderDetails.Select(d => new OrderDetailReadDto {
            ItemId = d.ItemId,
            ItemName = d.Item.Name,
            Quantity = d.Quantity,
            Price = d.Price,
            Total = d.Total
            }).ToList()
         });
    }

    // Crear una orden
    public async Task<OrderReadDto> CreateOrderAsync(OrderCreateDto dto)
    {
        var order = new Order
        {
            PersonId = dto.PersonId,
            Number = dto.Number,
            CreatedBy = dto.CreatedBy,
            CreatedAt = dto.CreatedAt,
            UpdatedBy = dto.UpdatedBy,
            UpdatedAt = dto.UpdatedAt,
            OrderDetails = dto.OrderDetails.Select(d => new OrderDetail
            {
                ItemId = d.ItemId,
                Quantity = d.Quantity,
                Price = d.Price,
                Total = d.Price * d.Quantity,
                CreatedBy = dto.CreatedBy,
                CreatedAt = DateTime.Now
            }).ToList()
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        // devolver DTO
        return new OrderReadDto
        {
            OrderId = order.OrderId,
            Number = order.Number,
            CreatedBy = order.CreatedBy,
            CreatedAt = order.CreatedAt,
            UpdatedBy = order.UpdatedBy,
            UpdatedAt = order.UpdatedAt,
            Person = new PersonReadDto
            {
                PersonId = order.Person.PersonId,
                FirstName = order.Person.FirstName,
                LastName = order.Person.LastName,
                Email = order.Person.Email
            },
            OrderDetails = order.OrderDetails.Select(od => new OrderDetailReadDto
            {
                ItemId = od.ItemId,
                ItemName = od.Item.Name,
                Quantity = od.Quantity,
                Price = od.Price,
                Total = od.Total
            }).ToList()
        };
    }

    //DELETE: Eliminar una orden
    public async Task<bool> DeleteOrderAsync(int id)
    {
        var order = await _context.Orders
            .Include(o => o.OrderDetails)
            .FirstOrDefaultAsync(o => o.OrderId == id);

        if (order == null) return false;

        _context.OrderDetails.RemoveRange(order.OrderDetails);
        _context.Orders.Remove(order);

        await _context.SaveChangesAsync();
        return true;
    }
}
