using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EchoPOS.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesRepository _expenseRepository;

        public ExpensesController(IExpensesRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        // GET: /Expense
        public IActionResult Index(string filter)
        {
            var allExpenses = _expenseRepository.GetAllExpenses(); // Or from DbContext

            DateTime now = DateTime.Now;
            DateTime startDate = DateTime.MinValue;

            switch (filter)
            {
                case "Today":
                    startDate = now.Date;
                    allExpenses = allExpenses.Where(e => e.Date.Date == startDate).ToList();
                    break;
                case "ThisWeek":
                    int diff = (7 + (now.DayOfWeek - DayOfWeek.Monday)) % 7;
                    startDate = now.Date.AddDays(-1 * diff);
                    allExpenses = allExpenses.Where(e => e.Date >= startDate).ToList();
                    break;
                case "ThisMonth":
                    startDate = new DateTime(now.Year, now.Month, 1);
                    allExpenses = allExpenses.Where(e => e.Date >= startDate).ToList();
                    break;
                case "ThisYear":
                    startDate = new DateTime(now.Year, 1, 1);
                    allExpenses = allExpenses.Where(e => e.Date >= startDate).ToList();
                    break;
            }

            return View(allExpenses);
        }


        // GET: /Expense/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Expense/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expenses expenses)
        {
            if (ModelState.IsValid)
            {
                _expenseRepository.AddExpense(expenses);
                return RedirectToAction("Index");
            }
            return View(expenses);
        }

        // GET: /Expense/Edit/5
        public IActionResult Edit(int id)
        {
            var expenses = _expenseRepository.GetExpenseById(id);
            if (expenses == null)
            {
                return NotFound();
            }
            return View(expenses);
        }

        // POST: /Expense/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Expenses expenses)
        {
            if (ModelState.IsValid)
            {
                _expenseRepository.UpdateExpense(expenses);
                return RedirectToAction("Index");
            }
            return View(expenses);
        }

        // GET: /Expense/Delete/5
        public IActionResult Delete(int id)
        {
            var expenses = _expenseRepository.GetExpenseById(id);
            if (expenses == null)
            {
                return NotFound();
            }
            return View(expenses);
        }

        // POST: /Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _expenseRepository.DeleteExpense(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var expense = _expenseRepository.GetExpenseById(id); // Use your repository or context
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

    }
}
