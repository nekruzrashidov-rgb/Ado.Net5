namespace Infrastructure.Interface;
using Domain.Models;

public interface IOrderItemService
{
    Task<bool> AddOrderItemAsync(OrderItems orderItem);
    Task<List<OrderItems>> GetAllOrderItemsAsync();
    Task<bool> UpdateOrderItemAsync(OrderItems orderItem);
    Task<bool> DeleteOrderItemAsync(int id);

}
