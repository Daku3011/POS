using Dapper;
using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

public class TaxesRepository : ITaxesRepository
{
    private readonly IDbConnection _dbConnection;

    public object Taxes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public TaxesRepository(IConfiguration configuration)
    {
        _dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }

    // Get all Taxes
    public List<Taxes> GetAllTaxes()
    {
        var taxes = _dbConnection.Query<Taxes>(
            "GetAllTaxes",
            commandType: CommandType.StoredProcedure
        ).ToList();
        return taxes;
    }

    // Get a Tax by ID
    public Taxes GetTaxById(int id)
    {
        var tax = _dbConnection.QueryFirstOrDefault<Taxes>(
            "GetTaxById",
            new { Tax_Id = id },
            commandType: CommandType.StoredProcedure
        );
        return tax;
    }

    // Add a new Tax
    public void AddTax(Taxes tax)
    {
        var parameters = new
        {
            tax.Name,
            tax.Percentage
        };
        _dbConnection.Execute("AddTax", parameters, commandType: CommandType.StoredProcedure);
    }

    // Update an existing Tax
    public void UpdateTax(Taxes tax)
    {
        var parameters = new
        {
            Tax_Id = tax.Tax_Id, // ✅ Match with SP
            tax.Name,
            tax.Percentage
        };
        _dbConnection.Execute("UpdateTax", parameters, commandType: CommandType.StoredProcedure);
    }

    public void DeleteTax(int taxId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Tax_Id", taxId);

        _dbConnection.Execute("DeleteTax", parameters, commandType: CommandType.StoredProcedure);
    }

    public int GetTaxIdByPercentage(float percentage)
    {
        var parameters = new { Tax_Percentage = percentage };
        return _dbConnection.QueryFirstOrDefault<int>(
            "sp_GetTaxIdByPercentage",
            parameters,
            commandType: CommandType.StoredProcedure);
    }



}

