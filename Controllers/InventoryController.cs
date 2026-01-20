using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace EchoPOS.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly string _connectionString;

        public InventoryController(IInventoryRepository inventoryRepository, IConfiguration configuration)
        {
            _inventoryRepository = inventoryRepository;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private void LoadSuppliers()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Supplier_ID, Name FROM Suppliers", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader()) // Ensure reader is disposed
                {
                    List<SelectListItem> suppliers = new List<SelectListItem>();
                    while (reader.Read())
                    {
                        suppliers.Add(new SelectListItem
                        {
                            Value = reader["Supplier_ID"].ToString(),
                            Text = reader["Name"].ToString()
                        });
                    }
                    ViewBag.Suppliers = suppliers;
                }
            }
        }


        public IActionResult Index()
        {
            var inventoryList = _inventoryRepository.GetAllInventory();
            return View(inventoryList);
        }

        public IActionResult Details(int id)
        {
            var inventory = _inventoryRepository.GetInventoryById(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        public IActionResult Create()
        {
            LoadSuppliers();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _inventoryRepository.AddInventory(inventory);
                return RedirectToAction("Index", "Admin");
            }
            LoadSuppliers();
            return View(inventory);
        }

        public IActionResult Edit(int id)
        {
            LoadSuppliers();
            var inventory = _inventoryRepository.GetInventoryById(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        [HttpPost]
        public IActionResult Edit(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _inventoryRepository.UpdateInventory(inventory);
                return RedirectToAction("Index", "Admin");
            }
            LoadSuppliers();
            return View(inventory);
        }

        public IActionResult Delete(int id)
        {
            var inventory = _inventoryRepository.GetInventoryById(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return View(inventory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _inventoryRepository.DeleteInventory(id);
            return RedirectToAction("Index", "Admin");
        }
    }
}
