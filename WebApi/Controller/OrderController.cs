namespace WebApi.Controller;

using Domain.Models;
using Infrastructure.DTOS.Companies;
using Infrastructure.Interface;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/orders")]
public class OrderController
{

    private readonly IOrderService _orderService;
    
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<List<Domain.Models.Orders>> GetAllOrders()
    {
        return await _orderService.GetAllOrdersAsync();
    }
    

    [HttpGet("with-company-names")]
    public async Task<List<GetOrderWithCompanyName>> GetAllOrdersWithCompanyNames()
    {
        return await _orderService.GetAllOrdersWithCompanyNamesAsync();
    }
    
    [HttpPost]
    public async Task<bool> AddOrder(Orders order)
    {
        return await _orderService.AddOrderAsync(order);
    }

    [HttpPut("{id:int}")]
    public async Task<bool> UpdateOrder(int id, Orders order)
    {
        order.Id = id;
        return await _orderService.UpdateOrderAsync(order);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteOrder(int id)
    {
        return await _orderService.DeleteOrderAsync(id);
    }
}