using EchooPays.Repository;
using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EchoPOS.Controllers
{
    public class KitchenDashBoardController : Controller
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly ICategoryRepository _connectionString;
        private readonly IOrdersRepository _ordersRepository;
        private readonly ITablesRepository _tableRepository;
        private readonly IInventoryRepository _connectionnString;



        public KitchenDashBoardController(IMenuRepository menuRepository, ISuppliersRepository suppliersRepository, ICategoryRepository connectionString, IOrdersRepository ordersRepository, ITablesRepository tableRepository, IInventoryRepository connectionString_)
        {
            _menuRepository = menuRepository;
            _suppliersRepository = suppliersRepository;
            _connectionString = connectionString;
            _ordersRepository = ordersRepository;
            _tableRepository = tableRepository;
            _connectionnString = connectionString_;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Supplier()
        {
            var suppliers = await _suppliersRepository.GetAllSuppliersAsync();
            return PartialView("_SupplierPartial", suppliers);
        }
        public IActionResult Orders()
        {
            var orders = _ordersRepository.GetPendingKitchenOrders(); // Retrieve orders
            return PartialView("Orders", orders);  // Return the partial view to be rendered
        }

        public IActionResult Tables()
        {

            var tables = _tableRepository.GetAllTables();
            return PartialView("_TablesPartial", tables);
        }
        public async Task<IActionResult> MenuAsync()
        {
            try
            {
                var viewModel = new MenuListViewModel
                {
                    MenuItems = (List<Menu>)await _menuRepository.GetAllAsync(), // or await if async

                };

                return PartialView("_MenuPartial", viewModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Server error: " + ex.Message);
            }
        }
        public IActionResult Category()
        {
            var categories = _connectionString.GetAll();
            return PartialView("_CategoryPartial", categories);
        }


        public async Task<IActionResult> Inventory()
        {
            try
            {
                // Retrieve inventory items (replace with your actual method from repository)
                var inventoryItems = _connectionnString.GetAllInventory();

                // Pass the data to the partial view
                return PartialView("_InventoryPartial", inventoryItems);
            }
            catch (Exception ex)
            {
                // Handle errors (e.g., log them or show a user-friendly message)
                return StatusCode(500, "Server error: " + ex.Message);
            }
        }

        public IActionResult KitchenPanel()
        {
            var menuItems = _menuRepository.GetAllMenuItems();


            // Optional: log or debug
            if (menuItems == null || !menuItems.Any())
            {
                // Can log for debugging
                Console.WriteLine("No menu items retrieved.");
                menuItems = new List<Menu>();
            }

            return View(menuItems);

        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(int orderId, string status)
        {
            try
            {
                if (!string.IsNullOrEmpty(status))
                {
                    _ordersRepository.UpdateOrderStatus(orderId, status.ToLower()); // call repository
                }

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public IActionResult Delete(int id)
        {
            var inventory = _connectionnString.GetInventoryById(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _connectionnString.DeleteInventory(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> MarkOrderInProcess(int orderId)
        {
            try
            {
                bool updated = _ordersRepository.UpdateOrderStatus(orderId, "in process");

                if (updated)
                    return Json(new { success = true });
                else
                    return Json(new { success = false, message = "Failed to update order status." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult UpdateOrderItemStatus(int orderItemId, string orderitemstatus)
        {
            try
            {
                // Execute the stored procedure and get the result.
                var updatedOrderItem = _ordersRepository.UpdateOrderItemStatuss(orderItemId, orderitemstatus);

                // Check if an order item was returned (indicating success).
                if (updatedOrderItem != null)
                {
                    return Json(new { success = true, updatedOrderItem });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to update item status. Item not found." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult MarkOrderCompleted(int orderId)
        {
            var result = _ordersRepository.UpdateOrderStatus(orderId, "completed");
            return Json(new { success = result });
        }

    }
}
