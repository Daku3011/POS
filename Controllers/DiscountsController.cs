using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;


public class DiscountsController : Controller
{
    private readonly IDiscountsRepository _discountRepository;

    public DiscountsController(IDiscountsRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    // GET: Discount
    public IActionResult Index()
    {
        var discounts = _discountRepository.GetAllDiscounts();
        return View(discounts);
    }

    // GET: Discount/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Discount/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Discounts discounts)
    {
        if (ModelState.IsValid)
        {
            _discountRepository.AddDiscount(discounts);
            return RedirectToAction("Index", "Admin");
        }
        return View(discounts);
    }

    // GET: Discount/Edit/5
    // GET: Discount/Edit/5
    public IActionResult Edit(int id)
    {
        var discounts = _discountRepository.GetDiscountById(id);
        return discounts == null ? NotFound() : View(discounts);
    }

    // POST: Discount/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Discounts discounts)
    {
        if (!ModelState.IsValid)
            return View(discounts);

        _discountRepository.UpdateDiscount(discounts);
        return RedirectToAction("Index", "Admin");
    }
    // GET: Discounts/Delete/5
    public IActionResult Delete(int id)
    {
        var discount = _discountRepository.GetDiscountById(id);
        return discount == null ? NotFound() : View(discount);
    }

    // POST: Discounts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _discountRepository.DeleteDiscount(id);
        return RedirectToAction("Index", "Admin");
    }

    // GET: Discount/Details/5
    public IActionResult Details(int id)
    {
        var discounts = _discountRepository.GetDiscountById(id);
        if (discounts == null)
        {
            return NotFound();
        }
        return View(discounts);
    }
}
