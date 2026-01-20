using EchoPOS.Models;

namespace EchoPOS.Repository
{
    public interface IExpensesRepository
    {
        List<Expenses> GetAllExpenses();
        Expenses GetExpenseById(int id);
        void AddExpense(Expenses expenses);
        void UpdateExpense(Expenses expenses);
        void DeleteExpense(int id);
    }
}
