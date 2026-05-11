namespace Infrastructure.Interface;
using Domain.Models;
using Infrastructure.DTOS.Companies;

public interface IOrderService
{
    Task<bool> AddOrderAsync(Orders order);
    Task<List<Orders>> GetAllOrdersAsync();
    Task<List<GetOrderWithCompanyName>> GetAllOrdersWithCompanyNamesAsync();
    Task<bool> UpdateOrderAsync(Orders order);
    Task<bool> DeleteOrderAsync(int id);
}
