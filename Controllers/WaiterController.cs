using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EchoPOS.Controllers
{
    public class WaiterController : Controller
    {
        private readonly IReservationsRepository _reservationRepository;
        private readonly ITablesRepository _tablesRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IUsersRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly ICartRepository _cartRepository;


        public WaiterController(IReservationsRepository reservationRepository, ITablesRepository tablesRepository, IOrdersRepository ordersRepository, IUsersRepository userRepository, ICategoryRepository categoryRepository, IMenuRepository menuRepository, ICartRepository cartRepository)
        {
            _reservationRepository = reservationRepository;
            _tablesRepository = tablesRepository;
            _ordersRepository = ordersRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _menuRepository = menuRepository;
            _cartRepository = cartRepository;

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Tables()
        {

            var tables = _tablesRepository.GetAllTables();
            return View(tables);
        }

        // Reservations
        public IActionResult Reservations()
        {
            var reservations = _reservationRepository.GetAllReservations();
            return PartialView("_ReservationPartial", reservations);
        }
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

            return PartialView(viewModel);
        }



        [HttpPost]
        public IActionResult AddToCart(Cart model)
        {
            try
            {
                // Your logic to add item to cart (via repository / service)
                _cartRepository.AddToCart(model);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult OrderReady()
        {
            var readyOrders = _ordersRepository.GetReadyOrderItems();
            return View(readyOrders);
        }

        [HttpPost]
        public IActionResult MarkOrderCompleted(int orderItemId)
        {
            try
            {
                _ordersRepository.MarkOrderCompleted(orderItemId);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }




    }
}
