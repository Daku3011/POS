using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EchoPOS.Controllers
{
    public class CashierController : Controller
    {
        private readonly ITablesRepository _tablesRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IBillRepository _billRepository;
        private readonly IExpensesRepository _expenses;

        public CashierController(ITablesRepository tablesRepository, IOrdersRepository ordersRepository, IMenuRepository menuRepository, ICategoryRepository categoryRepository, ICartRepository cartRepository, IBillRepository billRepository, IExpensesRepository expenses)
        {
            _tablesRepository = tablesRepository;
            _ordersRepository = ordersRepository;
            _menuRepository = menuRepository;
            _categoryRepository = categoryRepository;
            _cartRepository = cartRepository;
            _billRepository = billRepository;
            _expenses = expenses;
        }

        public IActionResult Index()
        {
            return View();
        }

        /* Tables Dispaly*/
        public IActionResult Tables()
        {
            var tables = _tablesRepository.GetAllTables();
            return View(tables);
        }
        /* Category*/

        public IActionResult Category()
        {
            var categories = _categoryRepository.GetAll();
            return PartialView("_CategoryPartial", categories);
        }
        /*Menu*/
        public async Task<IActionResult> MenuAsync()
        {
            try
            {
                var viewModel = new MenuListViewModel
                {
                    MenuItems = (List<Menu>)await _menuRepository.GetAllAsync(), // or await if async

                };

                return View("_MenuPartial", viewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error: " + ex.Message);
            }
        }

        /*POS*/
        public async Task<IActionResult> POS(int Table_Id)
        {
            HttpContext.Session.SetInt32("Table_Id", Table_Id);

            var menuItems = await _menuRepository.GetAllAsync();
            var categories = await _menuRepository.GetAllCategoriesAsync();

            ViewBag.TableId = Table_Id;  // You can also use ViewBag for sending TableId to the View

            var viewModel = new MenuListViewModel
            {
                MenuItems = menuItems.ToList(),
                Categories = categories.ToList(),
                CartItems = new List<Cart>() // Or actual cart data
            };

            return View(viewModel);
        }

        /* Pending Orders*/
        public IActionResult Orders()
        {
            var orders = _ordersRepository.GetPendingKitchenOrders(); // Retrieve orders
            return PartialView("Orders", orders);  // Return the partial view to be rendered

        }


        /* Ready Order Before Serving */
        [HttpGet]
        public IActionResult OrderReady()
        {
            var readyOrders = _ordersRepository.GetReadyOrderItems();
            return PartialView("OrderReady", readyOrders);
        }

        /* Bills*/
        [HttpGet]
        public IActionResult Bill(int orderId)
        {
            var bills = _billRepository.GetAllBills();
            var summary = _billRepository.GetPaymentSummary();
            //_billRepository.ClearDailyPaymentSummary();
            // Pass payment summary values to the view via ViewBag
            ViewBag.CashTotal = summary?.CashTotal ?? 0;
            ViewBag.UPITotal = summary?.UPITotal ?? 0;
            ViewBag.CardTotal = summary?.CardTotal ?? 0;
            ViewBag.GrandTotal = summary?.GrandTotal ?? 0;

            return View(bills);
        }

        // GET: /Expense
        public IActionResult Expenses(string filter)
        {
            var allExpenses = _expenses.GetAllExpenses();
            var now = DateTime.Now;
            var startDate = filter switch
            {
                "Today" => now.Date,
                "ThisWeek" => now.Date.AddDays(-1 * ((7 + (now.DayOfWeek - DayOfWeek.Monday)) % 7)),
                "ThisMonth" => new DateTime(now.Year, now.Month, 1),
                "ThisYear" => new DateTime(now.Year, 1, 1),
                _ => DateTime.MinValue
            };

            if (startDate > DateTime.MinValue)
            {
                allExpenses = allExpenses
                    .Where(e => e.Date.Date >= startDate && e.Date.Date <= now.Date)
                    .ToList();
            }

            return View(allExpenses);
        }







    }
}
