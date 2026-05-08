namespace Infrastructure.Interface;
using Domain.Models;
public interface IMenuService
{
    Task<bool> AddMenuAsync(Menus menu);
    Task<List<Menus>> GetAllMenusAsync();
    Task<bool> UpdateMenuAsync(Menus menu);
    Task<bool> DeleteMenuAsync(int id);
}
