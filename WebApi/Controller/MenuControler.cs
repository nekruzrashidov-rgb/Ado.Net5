namespace WebApi.Controller;

using Domain.Models;

using Infrastructure.Interface;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/menu")]
public class MenuController
{

    private readonly IMenuService _menuService;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
    }

    [HttpGet]
    public async Task<List<Domain.Models.Menus>> GetAllMenus()
    {
        return await _menuService.GetAllMenusAsync();
    }

    
    [HttpPost]
    public async Task<bool> AddMenu(Menus menu)
    {
        return await _menuService.AddMenuAsync(menu);
    }

    [HttpPut("{id:int}")]
    public async Task<bool> UpdateMenu(int id, Menus menu)
    {
        menu.Id = id;
        return await _menuService.UpdateMenuAsync(menu);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteMenu(int id)
    {
        return await _menuService.DeleteMenuAsync(id);
    }
}