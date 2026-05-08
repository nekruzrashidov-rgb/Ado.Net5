namespace WebApi.Controller;

using Domain.Models;

using Infrastructure.Interface;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/company")]
public class CompanyController
{

    private readonly ICompanyService _companyService = new CompanyService();

    [HttpGet]
    public async Task<List<Domain.Models.Companies>> GetAllCompanies()
    {
        return await _companyService.GetAllCompaniesAsync();
    }

    
    [HttpPost]
    public async Task<bool> AddCompany(Companies company)
    {
        return await _companyService.AddCompanyAsync(company);
    }

    [HttpPut("{id:int}")]
    public async Task<bool> UpdateCompany(int id, Companies company)
    {
        company.Id = id;
        return await _companyService.UpdateCompanyAsync(company);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteCompany(int id)
    {
        return await _companyService.DeleteCompanyAsync(id);
    }
}