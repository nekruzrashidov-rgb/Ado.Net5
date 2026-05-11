namespace Infrastructure.Interface;
using Domain.Models;
using Infrastructure.DTOS.Companies;

public interface ICompanyService
{
    Task<bool> AddCompanyAsync(Companies company);
    Task<List<Companies>> GetAllCompaniesAsync();
    Task<List<GetCompaniesWithSubscriptionsDto>> GetAllCompaniesWithSubscriptionsAsync();
    Task<bool> UpdateCompanyAsync(Companies company);
    Task<bool> DeleteCompanyAsync(int id);
}
