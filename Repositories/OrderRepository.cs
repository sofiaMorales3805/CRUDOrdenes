using System.Linq;
using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders
            .Include(o => o.Person)           // Incluye la persona
            .Include(o => o.OrderDetails)     // Incluye los detalles
                .ThenInclude(od => od.Item)   // Incluye cada Item
            .ToListAsync();
    }

    public async Task<Order> AddOrderAsync(Order order)
     {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await _context.Orders
            .Include(o => o.Person)
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Item)
            .FirstOrDefaultAsync(o => o.OrderId == id);
    }

    public async Task<bool> DeleteOrderAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return false;

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }
}
