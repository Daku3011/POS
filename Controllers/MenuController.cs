using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EchoPOS.Repositories
{
    public class MenuController : Controller
    {
        private readonly IMenuRepository _menuRepository;

        public MenuController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IActionResult> Index(int Table_Id)
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


        public ActionResult CenterPanel()
        {
            // Returns only the central panel as a partial view
            return View();
        }

        // GET: Create Menu Item
        public async Task<IActionResult> Create()
        {
            var categories = await _menuRepository.GetAllCategoriesAsync();
            ViewBag.Category_Id = new SelectList(categories, "Category_Id", "Name");  // Correct ViewBag variable name

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Menu menu)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _menuRepository.GetAllCategoriesAsync();
                ViewBag.Category_Id = new SelectList(categories, "Category_Id", "Name", menu.Category_Id);
                return View(menu);
            }
            await _menuRepository.AddAsync(menu);
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var menuItem = await _menuRepository.GetByIdAsync(id);
            if (menuItem == null) return NotFound();

            var categories = await _menuRepository.GetAllCategoriesAsync();
            ViewBag.Category_Id = new SelectList(categories, "Category_Id", "Name", menuItem.Category_Id);

            return View(menuItem);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Menu menu, IFormFile ImageFile)
        {
            if (!ModelState.IsValid)
            {
                var categories = await _menuRepository.GetAllCategoriesAsync();
                ViewBag.Category_Id = new SelectList(categories, "Category_Id", "Name", menu.Category_Id);
                return View(menu);
            }

            // Handle image file upload
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", ImageFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }
                menu.Image_Url = "/images/" + ImageFile.FileName; // Save the image URL
            }

            await _menuRepository.UpdateAsync(menu);  // Make sure your repository handles the image URL properly.
            return RedirectToAction("Index", "Admin");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var menuItem = await _menuRepository.GetByIdAsync(id);
            return menuItem == null ? NotFound() : View(menuItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _menuRepository.sp_DeleteMenu(id);
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var menuItem = await _menuRepository.GetByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

    }
}
