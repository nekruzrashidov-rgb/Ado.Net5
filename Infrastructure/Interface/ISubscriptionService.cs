namespace Infrastructure.Interface;
using Domain.Models;
public interface ISubscriptionService
{
    Task<bool> AddSubscriptionAsync(Subscriptions subscription);
    Task<List<Subscriptions>> GetAllSubscriptionsAsync();
    Task<bool> UpdateSubscriptionAsync(Subscriptions subscription);
    Task<bool> DeleteSubscriptionAsync(int id);
}
