using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EchoPOS.Controllers
{
    public class TablesController : Controller
    {
        private readonly ITablesRepository _tableRepository;

        public TablesController(ITablesRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var tables = _tableRepository.GetAllTables();
            return View(tables);
        }
        [HttpPost]
        public IActionResult Index(int Table_Id)
        {
            HttpContext.Session.SetInt32("Table_Id", Table_Id);

            // Now just redirect to GET version to prevent form resubmission
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var table = _tableRepository.GetTableById(id);
            if (table == null)
                return NotFound();
            return View(table);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tables table)
        {
            if (ModelState.IsValid)
            {
                _tableRepository.AddTable(table);

                return RedirectToAction("Index", "Admin");
            }
            return View(table);
        }

        public IActionResult Edit(int id)
        {
            var table = _tableRepository.GetTableById(id);
            if (table == null)
                return NotFound();
            return View(table);

        }

        [HttpPost]
        public IActionResult Edit(Tables table)
        {
            if (ModelState.IsValid)
            {
                _tableRepository.UpdateTable(table);
                return RedirectToAction("Index", "Admin");
            }
            return View(table);

        }

        public IActionResult Delete(int id)
        {
            var table = _tableRepository.GetTableById(id);
            if (table == null)
                return NotFound();
            return View(table);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _tableRepository.DeleteTable(id);
            return RedirectToAction("Index", "Admin");
        }
    }

}
