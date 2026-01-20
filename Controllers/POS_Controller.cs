using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EchoPOS.Controllers
{
    public class POS_Controller : Controller
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ITaxesRepository _taxesRepository;
        private readonly IDiscountsRepository _discountsRepository;
        private readonly IOrdersRepository _ordersRepository;
        public POS_Controller(IMenuRepository menuRepository, ICategoryRepository categoryRepository, ICartRepository cartRepository, IOrdersRepository ordersRepository)
        {
            _menuRepository = menuRepository;
            _categoryRepository = categoryRepository;
            _cartRepository = cartRepository;
            _ordersRepository = ordersRepository;
        }
        public async Task<IActionResult> Index(int Table_Id)
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
        /*
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
        */
        /*  [HttpPost]
          public IActionResult AddToCart(int table_id, int menu_item_id, decimal price, int quantity)
          {
              try
              {
                  decimal total_price = price * quantity;

                  _cartRepository.AddToCart(table_id, menu_item_id, price, quantity, total_price);

                  return Json(new { success = true });
              }
              catch (Exception ex)
              {
                  return Json(new { success = false, message = ex.Message });
              }
          }*/
        [HttpPost]
        public IActionResult AddToCart(int? table_id, int menu_item_id, decimal price, int quantity)
        {
            try
            {
                // Fallback to session if table_id is not sent in the request
                if (table_id == null || table_id == 0)
                {
                    table_id = HttpContext.Session.GetInt32("Table_Id");
                }

                if (table_id == null || table_id == 0)
                {
                    return Json(new { success = false, message = "Table ID not found." });
                }

                decimal total_price = price * quantity;
                _cartRepository.AddToCart(table_id.Value, menu_item_id, price, quantity, total_price);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }



        [HttpGet]
        public IActionResult GetCartPanelPartial(int tableId)
        {
            // Get the cart items for the given table
            var cartItems = _cartRepository.GetCartItemsByTable(tableId);

            // Return the partial view with cart items
            return PartialView(cartItems);
        }
        public IActionResult CartViewPartial(int table_id)
        {
            int user_id = 1; // 🔁 Replace with actual logic to get current user ID (e.g., from session or auth)
            var cart_items = _cartRepository.GetCartItems(table_id);

            ViewBag.Taxes = _taxesRepository.GetAllTaxes();
            ViewBag.Discounts = _discountsRepository.GetAllDiscounts();


            return View(cart_items);
        }

        [HttpPost]
        public IActionResult AddToCart(int table_id, int menu_item_id, int quantity, decimal price)
        {
            // Calculate the total price for the item
            decimal totalPrice = price * quantity;

            // Add the item to the cart using the repository
            _cartRepository.AddToCart(table_id, menu_item_id, price, quantity, totalPrice);

            // Redirect to the ViewCart page with the table_id to show updated cart
            return RedirectToAction("ViewCart", new { table_id });
        }




    }
}
