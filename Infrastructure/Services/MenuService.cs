namespace Infrastructure.Services;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interface;
public class MenuService(DataContext context) : IMenuService
{    
    public async Task<bool> AddMenuAsync(Menus menu)
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = "insert into menus (MenuDate, IsActive, CreatedAt, UpdatedAt) values (@MenuDate, @IsActive, @CreatedAt, @UpdatedAt)";
        var existingMenu = connection.QueryFirstOrDefault<Menus>("select * from menus where MenuDate = @MenuDate", new { MenuDate = menu.MenuDate });
        
        if (existingMenu != null)
        {
            System.Console.WriteLine("A menu with this date already exists.");
            return false;
        }

        connection.Execute(sql, new { MenuDate = menu.MenuDate, IsActive = menu.IsActive, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
        return true;
    }



    public async Task<List<Menus>> GetAllMenusAsync()
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = "select * from menus";
        
        var menus = connection.Query<Menus>(sql).ToList();
        return menus;
    }


    public async Task<bool> UpdateMenuAsync(Menus menu)
    {
        using var connection = context.GetConnection();
        connection.Open();
        
        const string sql = "update menus set MenuDate = @MenuDate, IsActive = @IsActive, UpdatedAt = @UpdatedAt where id = @Id";
        var res = await connection.ExecuteAsync(sql, menu);
        
        if (res == 0)
        {
            Console.WriteLine("Menu with given Id not found.");
            return false;
        }

        connection.Execute(sql, new { MenuDate = menu.MenuDate, IsActive = menu.IsActive, UpdatedAt = DateTime.Now, Id = menu.Id });
        return true;
    }
    
    
    public async Task<bool> DeleteMenuAsync(int id)
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = "delete from menus where id = @Id";
        var res = await connection.ExecuteAsync(sql, new { Id = id });
        
        if (res == 0)
        {
            Console.WriteLine("Menu with given Id not found.");
            return false;
        }

        return true;
    }

}


