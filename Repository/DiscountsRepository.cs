using Dapper;
using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.Data.SqlClient;
using System.Data;

public class DiscountRepository : IDiscountsRepository
{
    private readonly IDbConnection _dbConnection;

    public object Discounts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public DiscountRepository(IConfiguration configuration)
    {
        _dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }

    public List<Discounts> GetAllDiscounts()
    {
        var discounts = _dbConnection.Query<Discounts>(
            "GetAllDiscounts",
            commandType: CommandType.StoredProcedure
        ).ToList();
        return discounts;
    }

    public Discounts GetDiscountById(int id)
    {
        var discount = _dbConnection.QueryFirstOrDefault<Discounts>(
            "GetDiscountById",
            new { DiscountId = id },
            commandType: CommandType.StoredProcedure
        );
        return discount;
    }

    public void AddDiscount(Discounts discounts)
    {
        var parameters = new
        {
            discounts.Name,
            discounts.Discount_Type,
            discounts.Value,
            discounts.Start_Date,
            discounts.End_Date
        };
        _dbConnection.Execute("AddDiscount", parameters, commandType: CommandType.StoredProcedure);
    }

    public void UpdateDiscount(Discounts discounts)
    {
        var parameters = new
        {
            Discount_Id = discounts.Discount_Id, // ✅ Match with SP
            discounts.Name,
            discounts.Discount_Type,
            discounts.Value,
            discounts.Start_Date,
            discounts.End_Date
        };
        _dbConnection.Execute("UpdateDiscount", parameters, commandType: CommandType.StoredProcedure);
    }

    public void DeleteDiscount(int id)
    {
        var parameters = new { DiscountId = id };
        _dbConnection.Execute("DeleteDiscount", parameters, commandType: CommandType.StoredProcedure);
    }

    public int GetDiscountIdByValue(float value)
    {
        var parameters = new { Discount_Value = value };
        return _dbConnection.QueryFirstOrDefault<int>(
            "sp_GetDiscountIdByValue",
            parameters,
            commandType: CommandType.StoredProcedure);
    }



}
