namespace WebApi.Controller;
using Domain.Models;
using Infrastructure.Interface;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/menuitems")]
public class MenuItemController
{
    private readonly IMenuItemService menuItemService = new MenuItemService();
    [HttpGet]
    public async Task<List<MenuItems>> GetAllMenuItems()
    {
        return await menuItemService.GetAllMenuItemsAsync();
    }

    [HttpPost]
    public async Task<bool> AddMenuItem([FromBody] MenuItems menuItem)
    {
        return await menuItemService.AddMenuItemAsync(menuItem);
    }

    [HttpPut("{id:int}")]
    public async Task<bool> UpdateMenuItem(int id, MenuItems menu)
    {
        menu.Id = id;
        return await menuItemService.UpdateMenuItemAsync(menu);
    }

    [HttpDelete("{id:int}")]
    public async Task<bool> DeleteMenuItem(int id)
    {
        return await menuItemService.DeleteMenuItemAsync(id);   
    }

}