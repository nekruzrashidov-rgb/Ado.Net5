namespace WebApi.Controller;

using Domain.Models;

using Infrastructure.Interface;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/orderitems")]
public class OrderItemController
{

    private readonly IOrderItemService _orderItemService = new OrderItemService();

    [HttpGet]
    public async Task<List<Domain.Models.OrderItems>> GetAllOrderItems()
    {
        return await _orderItemService.GetAllOrderItemsAsync();
    }

    
    [HttpPost]
    public async Task<bool> AddOrderItem(OrderItems orderItem)
    {
        return await _orderItemService.AddOrderItemAsync(orderItem);
    }

    [HttpPut("{id:int}")]
    public async Task<bool> UpdateOrderItem(int id, OrderItems orderItem)
    {
        orderItem.Id = id;
        return await _orderItemService.UpdateOrderItemAsync(orderItem);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteOrderItem(int id)
    {
        return await _orderItemService.DeleteOrderItemAsync(id);
    }
}