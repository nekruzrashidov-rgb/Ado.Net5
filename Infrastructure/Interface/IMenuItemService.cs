namespace Infrastructure.Interface;
using Domain.Models;
public interface IMenuItemService
{
    Task<bool> AddMenuItemAsync(MenuItems menuItem);
    Task<List<MenuItems>> GetAllMenuItemsAsync();
    Task<bool> UpdateMenuItemAsync(MenuItems menuItem);
    Task<bool> DeleteMenuItemAsync(int id);
}
