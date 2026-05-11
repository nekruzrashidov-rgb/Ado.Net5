namespace Infrastructure.Services;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.DTOS.Companies;
using Infrastructure.Interface;
public class OrderItemService(DataContext context) : IOrderItemService
{
    
    public async Task<bool> AddOrderItemAsync(OrderItems orderItem)
    {
        using var connection = context.GetConnection();
        connection.Open();

        if(orderItem.OrderId <= 0 || orderItem.MenuItemId <=  0 || orderItem.Quantity <= 0 || orderItem.Price < 0 || orderItem.Price < 0)
        {
            System.Console.WriteLine("OrderId and MenuItemId must be greater than 0, Quantity must be positive, and Price cannot be negative.");
            return false;
        }

        const string sql = "insert into order_items (OrderId, MenuItemId, Quantity, Price) values (@OrderId, @MenuItemId, @Quantity, @Price)";
        var existingOrderItem = connection.QueryFirstOrDefault<OrderItems>("select * from order_items where OrderId = @OrderId and MenuItemId = @MenuItemId", new { OrderId = orderItem.OrderId, MenuItemId = orderItem.MenuItemId });

        if (existingOrderItem != null)
        {
            System.Console.WriteLine("An order item with this order and menu item already exists.");
            return false;
        }

        connection.Execute(sql, new { OrderId = orderItem.OrderId, MenuItemId = orderItem.MenuItemId, Quantity = orderItem.Quantity, Price = orderItem.Price });
        return true;
    }



    public async Task<List<OrderItems>> GetAllOrderItemsAsync()
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = "select * from order_items";
        
        var orders = connection.Query<OrderItems>(sql).ToList();
        return orders;
    }


    public async Task<bool> UpdateOrderItemAsync(OrderItems order)
    {
        using var connection = context.GetConnection();
        connection.Open();
        
        if(order.OrderId <= 0 || order.MenuItemId <= 0 || order.Quantity <= 0 || order.Price < 0)
        {
            System.Console.WriteLine("OrderId and MenuItemId must be greater than 0, Quantity must be positive, and Price cannot be negative.");
            return false;
        }

        const string sql = "update order_items set OrderId = @OrderId, MenuItemId = @MenuItemId, Quantity = @Quantity, Price = @Price where id = @Id";
        var res = await connection.ExecuteAsync(sql, order);
        
        if (res == 0)
        {
            Console.WriteLine("Order item with given Id not found.");
            return false;
        }

        connection.Execute(sql, new { OrderId = order.OrderId, MenuItemId = order.MenuItemId, Quantity = order.Quantity, Price = order.Price, Id = order.Id });
        return true;
    }
    
    
    public async Task<bool> DeleteOrderItemAsync(int id)
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = "delete from order_items where id = @Id";
        var res = await connection.ExecuteAsync(sql, new { Id = id });
        
        if (res == 0)
        {
            Console.WriteLine("Order item with given Id not found.");
            return false;
        }

        return true;
    }


}


