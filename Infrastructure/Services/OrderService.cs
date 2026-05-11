namespace Infrastructure.Services;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.DTOS.Companies;
using Infrastructure.Interface;
public class OrderService(DataContext context) : IOrderService
{

    public async Task<bool> AddOrderAsync(Orders order)
    {
        using var connection = context.GetConnection();
        connection.Open();

        if(order.CompanyId <= 0 || order.TotalAmount < 0 || string.IsNullOrWhiteSpace(order.Status))
        {
            System.Console.WriteLine("CompanyId must be greater than 0, TotalAmount cannot be negative and Status is required.");
            return false;
        }

        const string sql = "insert into orders (OrderDate, CompanyId, CreatedAt, UpdatedAt, TotalAmount, Status) values (@OrderDate, @CompanyId, @CreatedAt, @UpdatedAt, @TotalAmount, @Status)";
        var existingOrder = connection.QueryFirstOrDefault<Orders>("select * from orders where OrderDate = @OrderDate", new { OrderDate = order.OrderDate });
        
        if (existingOrder != null)
        {
            System.Console.WriteLine("An order with this date already exists.");
            return false;
        }

        connection.Execute(sql, new { OrderDate = order.OrderDate, CompanyId = order.CompanyId, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, TotalAmount = order.TotalAmount, Status = order.Status });
        return true;
    }



    public async Task<List<Orders>> GetAllOrdersAsync()
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = "select * from orders";
        
        var orders = connection.Query<Orders>(sql).ToList();
        return orders;
    }


    public async Task<bool> UpdateOrderAsync(Orders order)
    {
        using var connection = context.GetConnection();
        connection.Open();
        
        if(order.CompanyId <= 0 || order.TotalAmount < 0 || string.IsNullOrWhiteSpace(order.Status))
        {
            System.Console.WriteLine("CompanyId must be greater than 0, TotalAmount cannot be negative and Status is required.");
            return false;
        }

        const string sql = "update orders set OrderDate = @OrderDate, CompanyId = @CompanyId, UpdatedAt = @UpdatedAt, TotalAmount = @TotalAmount, Status = @Status where id = @Id";
        var res = await connection.ExecuteAsync(sql, order);
        
        if (res == 0)
        {
            Console.WriteLine("Order with given Id not found.");
            return false;
        }

        connection.Execute(sql, new { OrderDate = order.OrderDate, CompanyId = order.CompanyId, UpdatedAt = DateTime.Now, TotalAmount = order.TotalAmount, Status = order.Status, Id = order.Id });
        return true;
    }
    
    
    public async Task<bool> DeleteOrderAsync(int id)
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = "delete from orders where id = @Id";
        var res = await connection.ExecuteAsync(sql, new { Id = id });
        
        if (res == 0)
        {
            Console.WriteLine("Order with given Id not found.");
            return false;
        }

        return true;
    }

    public async Task<List<GetOrderWithCompanyName>> GetAllOrdersWithCompanyNamesAsync()
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = @"select o.Id as OrderId, o.CompanyId, o.OrderDate, c.Name as CompanyName
                            from orders o
                            join companies c on o.CompanyId = c.Id
                            group by o.Id, o.CompanyId, o.OrderDate, c.Name";
        
        var result = await connection.QueryAsync<GetOrderWithCompanyName>(sql);
        return result.ToList();
    }

}


       
