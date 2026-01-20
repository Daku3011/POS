using Dapper;
using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.Data.SqlClient;
using System.Data;

public class ExpensesRepository : IExpensesRepository
{
    private readonly string _connectionString;

    public ExpensesRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public List<Expenses> GetAllExpenses()
    {
        using var connection = new SqlConnection(_connectionString);
        return connection.Query<Expenses>("sp_GetAllExpenses", commandType: CommandType.StoredProcedure).ToList();
    }

    public Expenses GetExpenseById(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        return connection.QueryFirstOrDefault<Expenses>(
            "sp_GetExpenseById",
            new { Id = id },
            commandType: CommandType.StoredProcedure
        );
    }

    public void AddExpense(Expenses expenses)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Execute("sp_AddExpense", new
        {
            expenses.Category,
            expenses.Amount,
            expenses.Date,
            expenses.Note
        }, commandType: CommandType.StoredProcedure);
    }

    public void UpdateExpense(Expenses expenses)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Execute("sp_UpdateExpense", new
        {
            expenses.Id,
            expenses.Category,
            expenses.Amount,
            expenses.Date,
            expenses.Note
        }, commandType: CommandType.StoredProcedure);
    }

    public void DeleteExpense(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Execute("sp_DeleteExpense", new { Id = id }, commandType: CommandType.StoredProcedure);
    }
}
