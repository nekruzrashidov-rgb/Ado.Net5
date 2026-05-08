namespace Infrastructure.Interface;
using Domain.Models;
public interface IOrderService
{
    Task<bool> AddOrderAsync(Orders order);
    Task<List<Orders>> GetAllOrdersAsync();
    Task<bool> UpdateOrderAsync(Orders order);
    Task<bool> DeleteOrderAsync(int id);
}
