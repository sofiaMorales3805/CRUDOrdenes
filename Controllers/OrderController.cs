using Microsoft.AspNetCore.Mvc;
using Api.Models.Dtos;
using Api.Services;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service; //Variable para conectarse con el service
    public OrderController(IOrderService service)
    {
        _service = service;
    }
    //Get todas las ordenes
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _service.GetAllOrdersAsync();
        if (orders == null) return NotFound(); //404: No se encontro 
        return Ok(orders); //200: Se encontro Ordenes
    }
    //Crear una orden 
    [HttpPost]
    public async Task<IActionResult> Create(OrderCreateDto dto)
    {
        var order = await _service.CreateOrderAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = order.OrderId }, order);
    }
}
