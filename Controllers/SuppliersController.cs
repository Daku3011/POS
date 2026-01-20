
using EchooPays.Repository;
using EchoPOS.Models;
using Microsoft.AspNetCore.Mvc;

namespace EchooPays.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISuppliersRepository _supplierRepository;

        public SuppliersController(ISuppliersRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        // ✅ GET: Suppliers (List all suppliers)
        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierRepository.GetAllSuppliersAsync();
            return View(suppliers);
        }

        // ✅ GET: Suppliers/Details/5 (View supplier details)
        public async Task<IActionResult> Details(int id)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(id);
            if (supplier == null)
                return NotFound();

            return View(supplier);
        }

        // ✅ GET: Suppliers/Create (Show form to create new supplier)
        public IActionResult Create()
        {
            return View();
        }

        // ✅ POST: Suppliers/Create (Save new supplier)
        [HttpPost]
        public IActionResult Create(Suppliers su)
        {
            if (ModelState.IsValid)
            {
                _supplierRepository.sp_AddSupplier(su);
                return RedirectToAction("Index", "Admin");
            }
            return View(su);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Suppliers supp = _supplierRepository.sp_GetSupplierById(id).FirstOrDefault(); // Get single brand object
            if (supp == null)
            {
                return NotFound();
            }
            return View(supp);

        }

        [HttpPost]

        public IActionResult Edit(Suppliers Suppliers)
        {
            if (ModelState.IsValid)
            {
                // Ensure brand_id is being received
                if (Suppliers.Supplier_Id == 0)
                {
                    ModelState.AddModelError("", "Invalid brand ID");
                    return View(Suppliers);
                }

                _supplierRepository.sp_UpdateSupplier(Suppliers); // Call update method
                return RedirectToAction("Index", "Admin");
            }
            return View(Suppliers);

        }

        // ✅ GET: Confirm Delete Page
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(id);
            if (supplier == null) return NotFound();

            return View(supplier);
        }

        // ✅ POST: Handle Delete Request
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] // Security measure
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _supplierRepository.DeleteSupplierAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult DeleteConfirmed(int id)
        {
            _supplierRepository.sp_DeleteSuppliers(id);
            return RedirectToAction("Index", "Admin");
        }
    }
}
