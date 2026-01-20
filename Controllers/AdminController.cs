using EchooPays.Repository;
using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace EchoPOS.Controllers
{
    public class AdminController : Controller
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly ITablesRepository _tablesRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IUsersRepository _userRepository;
        private readonly ITaxesRepository _taxesRepository;
        private readonly IDiscountsRepository _discountsRepository;
        private readonly IReservationsRepository _reservationsRepository;
        private readonly IEmployee_ShiftsRepository _shiftsRepository;
        private readonly IBillRepository _billRepository;

        public AdminController(IInventoryRepository inventoryRepository, ISuppliersRepository suppliersRepository, ITablesRepository tablesRepository, IOrdersRepository ordersRepository, IMenuRepository menuRepository, ICategoryRepository categoryRepository, ICartRepository cartRepository, IUsersRepository userRepository, ITaxesRepository taxesRepository, IDiscountsRepository discountsRepository, IReservationsRepository reservationsRepository, IEmployee_ShiftsRepository shiftsRepository, IBillRepository billRepository)
        {
            _inventoryRepository = inventoryRepository;
            _suppliersRepository = suppliersRepository;
            _tablesRepository = tablesRepository;
            _ordersRepository = ordersRepository;
            _menuRepository = menuRepository;
            _categoryRepository = categoryRepository;
            _cartRepository = cartRepository;
            _userRepository = userRepository;
            _taxesRepository = taxesRepository;
            _discountsRepository = discountsRepository;
            _reservationsRepository = reservationsRepository;
            _shiftsRepository = shiftsRepository;
            _billRepository = billRepository;
        }



        /*Dashboard*/
        public IActionResult Index()
        {
            return View();
        }

        /* Tables */
        public IActionResult Tables()
        {
            var tables = _tablesRepository.GetAllTables();
            return View(tables);
        }

        /*Category*/
        public IActionResult Category()
        {
            var categories = _categoryRepository.GetAll();
            return View(categories);
        }
        /*Menu*/
        public async Task<IActionResult> Menu(int Table_Id)
        {
            var tableId = HttpContext.Session.GetInt32("Table_Id");

            var menuItems = await _menuRepository.GetAllAsync();
            var categories = await _menuRepository.GetAllCategoriesAsync();

            ViewBag.TableId = Table_Id;

            var viewModel = new MenuListViewModel
            {
                MenuItems = menuItems.ToList(),
                Categories = categories.ToList(),
                CartItems = new List<Cart>() // Or actual cart data
            };

            return View(viewModel);
        }
        /* Users*/
        public IActionResult Users()
        {
            IEnumerable<Users> users = _userRepository.GetAllUsers();
            return View(users);
        }

        /*Reservations*/
        public IActionResult Reservations()
        {
            var reservations = _reservationsRepository.GetAllReservations();
            return View(reservations);
        }
        /* Suppliers*/
        public async Task<IActionResult> Suppliers()
        {
            var suppliers = await _suppliersRepository.GetAllSuppliersAsync();
            return View(suppliers);
        }
        /* Inventory */
        public async Task<IActionResult> Inventory()
        {
            var inventoryItems = _inventoryRepository.GetAllInventory();
            return View(inventoryItems);
        }
        /*Employee_shifts*/
        public IActionResult Employee_Shifts()
        {
            var shifts = _shiftsRepository.GetAllShifts();
            return View(shifts);
        }
        /* Discounts*/
        public IActionResult Discounts()
        {
            var discounts = _discountsRepository.GetAllDiscounts();
            return View(discounts);
        }
        /* Taxes */
        public IActionResult Taxes()
        {
            var taxes = _taxesRepository.GetAllTaxes();
            return View(taxes);  // Returns the list of taxes to the Index view
        }
        /* POS*/
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

        /* Order Pending in Kitchen*/
        public IActionResult OrdersPending()
        {
            var orders = _ordersRepository.GetPendingKitchenOrders(); // Retrieve orders
            return PartialView("OrdersPending", orders);  // Return the partial view to be rendered
        }

        /*Order Pending to Serve ,But are Completed Cooking */
        [HttpGet]
        public IActionResult OrderReady()
        {
            var readyOrders = _ordersRepository.GetReadyOrderItems();
            return PartialView("OrderReady", readyOrders);
        }

        /*Orders History*/
        public IActionResult OrderHistory()
        {
            var orderHistory = _ordersRepository.GetOrderHistory();
            return View(orderHistory);
        }
        /*Logout*/
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
        public IActionResult ViewBill(int orderId)
        {
            var bill = _billRepository.GetBillByOrderId(orderId);
            return View(bill);
        }
        /* Bills Pending Payment */

        [HttpGet]
        public IActionResult Bill(int orderId)
        {
            var bills = _billRepository.GetAllBills();
            var summary = _billRepository.GetPaymentSummary();

            // Pass payment summary values to the view via ViewBag
            ViewBag.CashTotal = summary?.CashTotal ?? 0;
            ViewBag.UPITotal = summary?.UPITotal ?? 0;
            ViewBag.CardTotal = summary?.CardTotal ?? 0;
            ViewBag.GrandTotal = summary?.GrandTotal ?? 0;

            return View(bills);
        }

        /* Bills Pending Payment */

        [HttpGet]
        public IActionResult BillHistory(int orderId)
        {
            var bills = _billRepository.GetAllBills();
            var summary = _billRepository.GetPaymentSummary();

            // Pass payment summary values to the view via ViewBag
            ViewBag.CashTotal = summary?.CashTotal ?? 0;
            ViewBag.UPITotal = summary?.UPITotal ?? 0;
            ViewBag.CardTotal = summary?.CardTotal ?? 0;
            ViewBag.GrandTotal = summary?.GrandTotal ?? 0;

            return View(bills);
        }




    }
}
