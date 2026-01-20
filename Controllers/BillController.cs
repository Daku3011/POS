using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EchoPOS.Controllers
{
    public class BillController : Controller
    {
        private readonly IBillRepository _billRepository;

        public BillController(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }
        public IActionResult Index()
        {
            // Get all bills
            var bills = _billRepository.GetAllBills();

            // Get payment summary (cash, upi, card, total)
            var summary = _billRepository.GetPaymentSummary();

            // Pass payment summary values to the view via ViewBag
            ViewBag.CashTotal = summary?.CashTotal ?? 0;
            ViewBag.UPITotal = summary?.UPITotal ?? 0;
            ViewBag.CardTotal = summary?.CardTotal ?? 0;
            ViewBag.GrandTotal = summary?.GrandTotal ?? 0;

            // Return the view with the list of bills
            return View(bills);
        }

        [HttpGet]
        public IActionResult GetPaymentSummary()
        {
            var summary = _billRepository.GetPaymentSummary();
            return Json(new
            {
                cash = summary?.CashTotal ?? 0,
                upi = summary?.UPITotal ?? 0,
                card = summary?.CardTotal ?? 0,
                grand = summary?.GrandTotal ?? 0
            });
        }
        [HttpPost]
        public IActionResult ClearPaymentSummary()
        {
            _billRepository.ClearDailyPaymentSummary(); // Call the method that resets the payment summary
            return Ok();
        }




        public IActionResult Bill(int orderId)
        {
            var billViewModel = _billRepository.GetBillDetailsByOrderId(orderId);

            if (billViewModel?.Bill == null)
            {
                ViewBag.Error = "Bill not found or not loaded properly.";

                // ✅ Return an empty model instead of null
                return View(new BillViewModel());
            }

            return View(billViewModel);
        }
        [HttpPost]
        public IActionResult PayFromDetails(int orderId, string method)
        {
            _billRepository.ProcessPayment(orderId, method);

            if (method == "Cash")
            {
                TempData["Success"] = "Payment successful using Cash!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Success"] = $"{method} payment successful!";
                return RedirectToAction("Index");
            }
        }
        public IActionResult GetFilteredData(string filter)
        {
            DateTime now = DateTime.Now;
            DateTime startDate = now.Date;

            switch (filter)
            {
                case "week":
                    int diff = (7 + (now.DayOfWeek - DayOfWeek.Monday)) % 7;
                    startDate = now.AddDays(-1 * diff).Date;
                    break;

                case "month":
                    startDate = new DateTime(now.Year, now.Month, 1);
                    break;

                default:
                    startDate = now.Date;
                    break;
            }

            // Get bills for the selected filter
            var filteredBills = _billRepository.GetAllBills()
                                .Where(b => b.Created_At.Date >= startDate && b.Created_At.Date <= now.Date)
                                .ToList();

            // Get payment summary from DB
            var paymentSummary = _billRepository.GetFilteredPaymentSummary(startDate, now);

            var responseData = new
            {
                summary = new
                {
                    cash = paymentSummary.CashTotal,
                    upi = paymentSummary.UPITotal,
                    card = paymentSummary.CardTotal,
                    grand = paymentSummary.GrandTotal
                },
                bills = filteredBills.Select(b => new
                {
                    bill_Id = b.Bill_Id,
                    order_Id = b.Order_Id,
                    tax_Percentage = b.Tax_Percentage,
                    discount_Value = b.Discount_Value,
                    total = b.Total,
                    created_At = b.Created_At.ToString("g"),
                    order_Status = b.Order_Status,
                    payment_Status_Name = b.Payment_Status_Name
                }).ToList()
            };

            return Json(responseData);
        }



    }






}
