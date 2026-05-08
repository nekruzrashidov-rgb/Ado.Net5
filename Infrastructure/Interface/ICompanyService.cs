namespace Infrastructure.Interface;
using Domain.Models;
public interface ICompanyService
{
    Task<bool> AddCompanyAsync(Companies company);
    Task<List<Companies>> GetAllCompaniesAsync();
    Task<bool> UpdateCompanyAsync(Companies company);
    Task<bool> DeleteCompanyAsync(int id);
}
