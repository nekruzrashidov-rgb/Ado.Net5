namespace Infrastructure.Interface;
using Domain.Models;
using Infrastructure.DTOS.Companies;

public interface ISubscriptionService
{
    Task<bool> AddSubscriptionAsync(Subscriptions subscription);
    Task<List<Subscriptions>> GetAllSubscriptionsAsync();
    Task<List<GetCompanyCountOrderCountSubscriptionCount>> GetCompanyCountOrderCountSubscriptionCountAsync();
    Task<bool> UpdateSubscriptionAsync(Subscriptions subscription);
    Task<bool> DeleteSubscriptionAsync(int id);

}
