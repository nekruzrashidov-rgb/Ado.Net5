namespace WebApi.Controller;

using Domain.Models;

using Infrastructure.Interface;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/subscriptions")]

public class SubscriptionController
{

    private readonly ISubscriptionService _subscriptionService = new SubscriptionService();

    [HttpGet]
    public async Task<List<Domain.Models.Subscriptions>> GetAllSubscriptions()
    {
        return await _subscriptionService.GetAllSubscriptionsAsync();
    }

    
    [HttpPost]
    public async Task<bool> AddSubscription(Subscriptions subscription)
    {
        return await _subscriptionService.AddSubscriptionAsync(subscription);
    }

    [HttpPut("{id:int}")]
    public async Task<bool> UpdateSubscription(int id, Subscriptions subscription)
    {
        subscription.Id = id;
        return await _subscriptionService.UpdateSubscriptionAsync(subscription);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteSubscription(int id)
    {
        return await _subscriptionService.DeleteSubscriptionAsync(id);
    }
}