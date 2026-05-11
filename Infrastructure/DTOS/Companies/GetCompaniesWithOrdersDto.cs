namespace Infrastructure.DTOS.Companies;

public class GetCompaniesWithSubscriptionsDto
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = "";
    public string CompanyAddress { get; set; } = "";
    public int SubscriptionCount { get; set; }

}
