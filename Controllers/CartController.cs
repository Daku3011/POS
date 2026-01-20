using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EchoPOS.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cart_repository;
        private readonly IOrdersRepository _orderRepository;
        private readonly ITaxesRepository _taxesRepository;
        private readonly IDiscountsRepository _discountsRepository;
        private object Result;

        public CartController(ICartRepository cart_repository, IOrdersRepository orderRepository, ITaxesRepository taxesRepository, IDiscountsRepository discountsRepository)
        {
            _cart_repository = cart_repository;
            _orderRepository = orderRepository;
            _taxesRepository = taxesRepository;
            _discountsRepository = discountsRepository;
        }

        public IActionResult GetCart()
        {
            int userId = 1;     // 🔁 Replace this with real session/auth logic
            int tableId = 2;    // 🔁 Replace this with the selected table logic (e.g., passed in ViewBag, TempData, session, etc.)

            var cartItems = _cart_repository.GetCartItems(tableId);
            return PartialView("_CartPartial", cartItems);
        }

        [HttpGet]
        public IActionResult AddToCart(int table_id)
        {
            // Ideally, fetch the menu items to display or other data for the form
            // Pass table_id to the view so it can be included in the form submission
            return View(table_id);  // This will render AddToCart.cshtml with the table_id
        }

        // POST method to add an item to the cart
        [HttpPost]
        public IActionResult AddToCart(int table_id, int menu_item_id, int quantity, decimal price)
        {
            // Calculate the total price for the item
            decimal totalPrice = price * quantity;

            // Add the item to the cart using the repository
            _cart_repository.AddToCart(table_id, menu_item_id, price, quantity, totalPrice);

            // Redirect to the ViewCart page with the table_id to show updated cart
            return RedirectToAction("ViewCart", new { table_id });
        }



        public IActionResult ViewCart(int table_id)
        {
            int user_id = 1; // 🔁 Replace with actual logic to get the current user ID

            var cart_items = _cart_repository.GetCartItems(table_id);

            ViewBag.Taxes = _taxesRepository.GetAllTaxes();
            ViewBag.Discounts = _discountsRepository.GetAllDiscounts();
            ViewBag.TableId = table_id;

            return View(cart_items); // ✅ Return partial view
        }



        [HttpPost]
        public IActionResult RemoveCartItem(int cartId)
        {
            try
            {
                _cart_repository.RemoveCartItem(cartId);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        public IActionResult PlaceOrder(int table_id, int user_id)
        {
            _cart_repository.ConvertCartToOrder(table_id, user_id);
            return RedirectToAction("ViewOrder", "Order", new { table_id });
        }


        [HttpPost]
        public IActionResult SubmitOrder(int tableId)
        {
            _cart_repository.SubmitOrder(tableId);
            return RedirectToAction("Index", "Menu", new { tableId = tableId });
        }

        [HttpPost]
        public IActionResult SubmitOrderKeepCart(int tableId)
        {
            _cart_repository.SubmitOrderKeepCart(tableId);
            return RedirectToAction("Index", "Menu", new { tableId = tableId });
        }

        [HttpPost]
        public IActionResult CloseOrder(int tableId)
        {
            try
            {
                _cart_repository.sp_ClearCart_NoUser(tableId);
                _cart_repository.UpdateTablesStatus(tableId, "Available");

                TempData["Success"] = "Order closed successfully.";
                return RedirectToAction("Index", "Tables"); // Redirect wherever you want
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error closing order.";
                return RedirectToAction("Index", "Cart"); // Or stay on Cart page
            }
        }

        [HttpPost]
        public IActionResult CloseOrderAndPrint(int tableId, int taxId, int discountId, decimal tax, decimal discount)
        {
            try
            {
                // 1. Fetch cart items
                var cartItems = _cart_repository.GetCartItems(tableId);
                if (cartItems == null || !cartItems.Any())
                {
                    return BadRequest("Cart is empty.");
                }

                // 2. Calculate totals
                decimal subtotal = cartItems.Sum(x => x.Price * x.Quantity);
                decimal taxAmount = subtotal * (tax / 100);
                decimal discountAmount = subtotal * (discount / 100);
                decimal grandTotal = subtotal + taxAmount - discountAmount;

                // 3. Get the latest Order ID for this table
                int orderId = _orderRepository.GetLatestOrderIdByTable(tableId);
                if (orderId == 0)
                {
                    return StatusCode(500, "No order found for this table.");
                }

                // 4. Insert Bill (ensure IDs are valid in DB or default to fallback values like 1)
                int billId = _cart_repository.InsertBill(orderId, taxId, discountId, grandTotal);
                if (billId <= 0)
                {
                    return StatusCode(500, "Failed to insert bill.");
                }

                // 5. Generate HTML Bill
                string billHtml = "<html><head><title>Bill</title></head><body>";
                billHtml += "<h2>Order Bill</h2><table border='1' cellpadding='5' cellspacing='0'><tr><th>Item</th><th>Qty</th><th>Price</th><th>Total</th></tr>";

                foreach (var item in cartItems)
                {
                    billHtml += $"<tr><td>{item.Name}</td><td>{item.Quantity}</td><td>{item.Price:F2}</td><td>{(item.Price * item.Quantity):F2}</td></tr>";
                }

                billHtml += "</table><br/>";
                billHtml += $"<p>Subtotal: {subtotal:F2}</p>";
                billHtml += $"<p>Tax: {taxAmount:F2}</p>";
                billHtml += $"<p>Discount: {discountAmount:F2}</p>";
                billHtml += $"<h3>Grand Total: {grandTotal:F2}</h3>";
                billHtml += "<p>Thank you!</p>";
                billHtml += "</body></html>";

                // 6. Clear Cart
                _cart_repository.sp_ClearCart_NoUser(tableId);

                // 7. Update Table status
                _cart_repository.UpdateTablesStatus(tableId, "Available");

                return Content(billHtml, "text/html");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error closing order and printing: {ex.Message}");
            }
        }



        [HttpPost]
        public JsonResult UpdateQuantity(int cartId, int change, int tableId, int userId)
        {
            try
            {
                // Get current item
                var cartItem = _cart_repository.GetCartItemById(cartId);
                if (cartItem == null)
                {
                    return Json(new { success = false });
                }

                int newQty = cartItem.Quantity + change;
                if (newQty <= 0)
                {
                    _cart_repository.RemoveCartItem(cartId);
                    return Json(new { success = true, newQuantity = 0 });
                }
                else
                {
                    _cart_repository.UpdateCartQuantity(cartId, change);
                    return Json(new { success = true, newQuantity = newQty });
                }
            }
            catch
            {
                return Json(new { success = false });
            }
        }


    }
}
