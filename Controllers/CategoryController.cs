using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;


namespace EchoPOS.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        // ✅ Show all categories
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _repository.GetAll();
            return View(categories);
        }

        // ✅ Show create form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // ✅ Create category
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _repository.sp_InsertCategory(category);
                return RedirectToAction("Index", "Admin");
            }

            return View(category);
        }

        // ✅ Show edit form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<Category> categoryList = _repository.sp_GetCategoryByID(id);
            Category category = categoryList.Count > 0 ? categoryList[0] : null;

            if (category == null)
                return NotFound();

            return View(category);
        }

        // ✅ Update category
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            _repository.sp_UpdateCategory(category);
            return RedirectToAction("Index", "Admin");
        }

        // ✅ Show Delete confirmation page
        public IActionResult Delete(int id)
        {
            var category = _repository.GetCategoryByID(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // ✅ Delete action (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.sp_DeleteCategory(id);
            return RedirectToAction("Index", "Admin");
        }


        // ✅ Show category details
        public IActionResult Details(int id)
        {
            var category = _repository.GetCategoryByID(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
    }
}
