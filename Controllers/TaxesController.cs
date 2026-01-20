using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EchoPOS.Controllers
{
    public class TaxesController : Controller
    {
        private readonly ITaxesRepository _taxesRepository;

        public TaxesController(ITaxesRepository taxesRepository)
        {
            _taxesRepository = taxesRepository;
        }

        // GET: Taxes
        public IActionResult Index()
        {
            var taxes = _taxesRepository.GetAllTaxes();
            return View(taxes);  // Returns the list of taxes to the Index view
        }

        // GET: Taxes/Details/{id}
        public IActionResult Details(int id)
        {
            var tax = _taxesRepository.GetTaxById(id);
            if (tax == null)
            {
                return NotFound();  // If tax not found, return NotFound
            }
            return View(tax);  // Return the details of the tax
        }

        // GET: Taxes/Create
        public IActionResult Create()
        {
            return View();  // Returns the view to create a new tax
        }

        // POST: Taxes/Create
        [HttpPost]
        public IActionResult Create(Taxes tax)
        {
            if (tax == null)
            {
                return BadRequest();  // If tax is null, return BadRequest
            }

            _taxesRepository.AddTax(tax);
            return RedirectToAction("Index", "Admin");  // After successful addition, redirect to the Index page
        }

        // GET: Taxes/Edit/{id}
        public IActionResult Edit(int id)
        {
            var tax = _taxesRepository.GetTaxById(id);
            if (tax == null)
            {
                return NotFound();  // If tax not found, return NotFound
            }
            return View(tax);  // Returns the tax details to edit
        }

        // POST: Taxes/Edit/{id}
        [HttpPost]
        public IActionResult Edit(int id, Taxes tax)
        {
            if (tax == null || tax.Tax_Id != id)
            {
                return BadRequest();  // If tax is invalid, return BadRequest
            }

            var existingTax = _taxesRepository.GetTaxById(id);
            if (existingTax == null)
            {
                return NotFound();  // If tax not found, return NotFound
            }

            _taxesRepository.UpdateTax(tax);
            return RedirectToAction("Index", "Admin");  // After successful update, redirect to the Index page
        }

        // GET: Taxes/Delete/{id}
        public IActionResult Delete(int id)
        {
            var tax = _taxesRepository.GetTaxById(id);
            if (tax == null)
            {
                return NotFound();  // If tax not found, return NotFound
            }
            return View(tax);  // Return the tax details to delete
        }

        // POST: Taxes/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var tax = _taxesRepository.GetTaxById(id);
            if (tax == null)
            {
                return NotFound();  // If tax not found, return NotFound
            }

            _taxesRepository.DeleteTax(id);
            return RedirectToAction("Index", "Admin");  // After successful deletion, redirect to the Index page
        }
    }
}
