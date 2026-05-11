namespace WebApi.Controller;

using Domain.Models;
using Infrastructure.Data;
using Infrastructure.DTOS.Companies;
using Infrastructure.Interface;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/company")]
public class CompanyController
{

    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }
    
    [HttpGet]
    public async Task<List<Companies>> GetAllCompanies()
    {
        return await _companyService.GetAllCompaniesAsync();
    }
   
    [HttpGet("with-subscriptions")]
    public async Task<List<GetCompaniesWithSubscriptionsDto>> GetAllCompaniesWithSubscriptions()
    {
        return await _companyService.GetAllCompaniesWithSubscriptionsAsync();
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