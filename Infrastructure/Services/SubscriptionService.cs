namespace Infrastructure.Services;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.DTOS.Companies;
using Infrastructure.Interface;

public class SubscriptionService(DataContext context) : ISubscriptionService
{


    public async Task<bool> AddSubscriptionAsync(Subscriptions subscription)
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = "insert into subscriptions (CompanyId, PlanType, MealsPerDay, StartDate, EndDate, Price, IsActive, CreatedAt, UpdatedAt) values (@CompanyId, @PlanType, @MealsPerDay, @StartDate, @EndDate, @Price, @IsActive, @CreatedAt, @UpdatedAt)";
        var existingSubscription = connection.QueryFirstOrDefault<Subscriptions>("select * from subscriptions where StartDate = @StartDate", new { StartDate = subscription.StartDate });
        
        if (existingSubscription != null)
        {
            System.Console.WriteLine("A subscription with this date already exists.");
            return false;
        }

        connection.Execute(sql, new { CompanyId = subscription.CompanyId, PlanType = subscription.PlanType, MealsPerDay = subscription.MealsPerDay, StartDate = subscription.StartDate, EndDate = subscription.EndDate, Price = subscription.Price, IsActive = subscription.IsActive, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
        return true;
    }



    public async Task<List<Subscriptions>> GetAllSubscriptionsAsync()
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = "select * from subscriptions";
        
        var subscriptions = connection.Query<Subscriptions>(sql).ToList();
        return subscriptions;
    }


    public async Task<bool> UpdateSubscriptionAsync(Subscriptions subscription)
    {
        using var connection = context.GetConnection();
        connection.Open();
        
        const string sql = "update subscriptions set CompanyId = @CompanyId, PlanType = @PlanType, MealsPerDay = @MealsPerDay, StartDate = @StartDate, EndDate = @EndDate, Price = @Price, IsActive = @IsActive, UpdatedAt = @UpdatedAt where id = @Id";
        var res = await connection.ExecuteAsync(sql, subscription);
        
        if (res == 0)
        {
            Console.WriteLine("Subscription with given Id not found.");
            return false;
        }

        connection.Execute(sql, new { CompanyId = subscription.CompanyId, PlanType = subscription.PlanType, MealPerDay = subscription.MealsPerDay, StartDate = subscription.StartDate, EndDate = subscription.EndDate, Price = subscription.Price, IsActive = subscription.IsActive, UpdatedAt = DateTime.Now, Id = subscription.Id });
        return true;
    }
    
    
    public async Task<bool> DeleteSubscriptionAsync(int id)
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = "delete from subscriptions where id = @Id";
        var res = await connection.ExecuteAsync(sql, new { Id = id });
        
        if (res == 0)
        {
            Console.WriteLine("Subscription with given Id not found.");
            return false;
        }

        return true;
    }

    public async Task<List<GetCompanyCountOrderCountSubscriptionCount>> GetCompanyCountOrderCountSubscriptionCountAsync()
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = @"SELECT (SELECT COUNT(*) FROM companies) AS CompanyId, 
                            (SELECT COUNT(*) FROM orders) AS OrderCount, 
                            (SELECT COUNT(*) FROM subscriptions) AS SubscriptionCount";
           
            var result = await connection.QueryAsync<GetCompanyCountOrderCountSubscriptionCount>(sql);
            return result.ToList();
    }

}


