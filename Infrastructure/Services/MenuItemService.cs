namespace Infrastructure.Services;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interface;

public class MenuItemService(DataContext context) : IMenuItemService
{
    public async Task<bool> AddMenuItemAsync(MenuItems menuItem)
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = "insert into menu_items (MenuId, Name, Description, Price, Category,  CreatedAt, UpdatedAt) values (@MenuId, @Name, @Description, @Price, @Category, @CreatedAt, @UpdatedAt)";
        var existingMenuItem = connection.QueryFirstOrDefault<MenuItems>("select * from menu_items where MenuId = @MenuId and Name = @Name", new { MenuId = menuItem.MenuId, Name = menuItem.Name });
        
        if (existingMenuItem != null)
        {
            System.Console.WriteLine("A menu item with this name already exists for the given menu.");
            return false;
        }

        connection.Execute(sql, new { MenuId = menuItem.MenuId, Name = menuItem.Name, Description = menuItem.Description, Price = menuItem.Price, Category = menuItem.Category, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
        return true;
    }



    public async Task<List<MenuItems>> GetAllMenuItemsAsync()
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = "select * from menu_items";
        
        var menuItems = connection.Query<MenuItems>(sql).ToList();
        return menuItems;
    }


    public async Task<bool> UpdateMenuItemAsync(MenuItems menuItem)
    {
        using var connection = context.GetConnection();
        connection.Open();
        
        const string sql = "update menu_items set MenuId = @MenuId, Name = @Name, Description = @Description, Price = @Price, Category = @Category, UpdatedAt = @UpdatedAt where id = @Id";
        var res = await connection.ExecuteAsync(sql, menuItem);
        
        if (res == 0)
        {
            Console.WriteLine("Menu item with given Id not found.");
            return false;
        }

        connection.Execute(sql, new { MenuId = menuItem.MenuId, Name = menuItem.Name, Description = menuItem.Description, Price = menuItem.Price, Category = menuItem.Category, UpdatedAt = DateTime.Now, Id = menuItem.Id });
        return true;
    }
    
    
    public async Task<bool> DeleteMenuItemAsync(int id)
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = "delete from menu_items where id = @Id";
        var res = await connection.ExecuteAsync(sql, new { Id = id });
        
        if (res == 0)
        {
            Console.WriteLine("Menu item with given Id not found.");
            return false;
        }

        return true;
    }

}
