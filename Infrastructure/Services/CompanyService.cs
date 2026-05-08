namespace Infrastructure.Services;

using Dapper;

using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interface;
public class CompanyService : ICompanyService
{

    private readonly DataContext context = new();


    public async Task<bool> AddCompanyAsync(Companies companie)
    {
        using var connection = context.GetConnection();
        connection.Open();

        if(string.IsNullOrWhiteSpace(companie.Name) || string.IsNullOrWhiteSpace(companie.Address) || string.IsNullOrWhiteSpace(companie.Phone) || string.IsNullOrWhiteSpace(companie.Email))
        {
            System.Console.WriteLine("All fields are required.");
            return false;
        }

        const string sql = "insert into companies (name, address, phone, email, CreatedAt, UpdatedAt) values (@Name, @Address, @Phone, @Email, @CreatedAt, @UpdatedAt)";
        var existingCompany = connection.QueryFirstOrDefault<Companies>("select * from companies where name = @Name", new { Name = companie.Name });
        
        if (existingCompany != null)
        {
            System.Console.WriteLine("A company with this name already exists.");
            return false;
        }

        connection.Execute(sql, new { Name = companie.Name, Address = companie.Address, Phone = companie.Phone, Email = companie.Email, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
        return true;
    }



    public async Task<List<Companies>> GetAllCompaniesAsync()
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = "select * from companies";
        
        var companies = connection.Query<Companies>(sql).ToList();
        return companies;
    }


    public async Task<bool> UpdateCompanyAsync(Companies companie)
    {
        using var connection = context.GetConnection();
        connection.Open();
        
        if(string.IsNullOrWhiteSpace(companie.Name) || string.IsNullOrWhiteSpace(companie.Address) || string.IsNullOrWhiteSpace(companie.Phone) || string.IsNullOrWhiteSpace(companie.Email))
        {
            System.Console.WriteLine("All fields are required.");
            return false;
        }

        const string sql = "update companies set name = @Name, address = @Address, phone = @Phone, email = @Email,CreatedAt = @CreatedAt, UpdatedAt = @UpdatedAt where id = @Id";
         var res = await connection.ExecuteAsync(sql, companie);
        
        if (res == 0)
        {
            Console.WriteLine("Company with given Id not found.");
            return false;
        }


        connection.Execute(sql, new { Name = companie.Name, Address = companie.Address, Phone = companie.Phone, Email = companie.Email, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, Id = companie.Id });
        return true;
    }
    
    
    public async Task<bool> DeleteCompanyAsync(int id)
    {
        using var connection = context.GetConnection();
        connection.Open();

        const string sql = "delete from companies where id = @Id";
        var res = await connection.ExecuteAsync(sql, new { Id = id });
        
        if (res == 0)
        {
            Console.WriteLine("Company with given Id not found.");
            return false;
        }

        return true;
    }

}
