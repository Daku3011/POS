using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EchoPOS.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationsRepository _reservationRepository;
        private readonly IUsersRepository _userRepository;
        private readonly ITablesRepository _tablesRepository;

        public ReservationsController(IReservationsRepository reservationRepository, IUsersRepository userRepository, ITablesRepository tablesRepository)
        {
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
            _tablesRepository = tablesRepository;
        }

        public IActionResult Index()
        {
            var reservations = _reservationRepository.GetAllReservations();
            return View(reservations);
        }

        public IActionResult Details(int id)
        {
            var reservation = _reservationRepository.GetReservationById(id);
            if (reservation == null)
                return NotFound();

            return View(reservation);
        }

        public IActionResult Create()
        {
            ViewBag.User_Id = new SelectList(_userRepository.GetAllUsers(), "User_Id", "Name");
            ViewBag.Table_Id = new SelectList(_tablesRepository.GetAllTables(), "Table_Id", "Table_Number");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Reservations reservation)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.User_Id = new SelectList(_userRepository.GetAllUsers(), "User_Id", "Name", reservation.User_Id);
                ViewBag.Table_Id = new SelectList(_tablesRepository.GetAllTables(), "Table_Id", "Table_Number", reservation.Table_Id);
                return View(reservation);
            }

            _reservationRepository.AddReservation(reservation);
            return RedirectToAction("Index", "Admin");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Retrieve the reservation by ID using the repository
            var reservation = _reservationRepository.GetReservationById(id);

            if (reservation == null)
            {
                return NotFound(); // Return a 404 if reservation is not found
            }

            // Populate ViewBag with dropdown lists for users and tables
            ViewBag.User_Id = new SelectList(_userRepository.GetAllUsers(), "User_Id", "Name", reservation.User_Id);
            ViewBag.Table_Id = new SelectList(_tablesRepository.GetAllTables(), "Table_Id", "Table_Number", reservation.Table_Id);

            return View(reservation); // Return the view with the reservation details
        }

        [HttpPost]
        public IActionResult Edit(Reservations reservation)
        {
            if (ModelState.IsValid) // Validate the model
            {
                // Ensure reservation ID is valid before updating
                if (reservation.Reservation_Id == 0)
                {
                    ModelState.AddModelError("", "Invalid reservation ID");
                    return View(reservation); // If invalid, return to the same view
                }

                // Update reservation using repository method
                _reservationRepository.UpdateReservation(reservation);

                // Redirect back to the reservation index page after successful update
                return RedirectToAction("Index", "Admin");

            }

            // If the model is not valid, return the view with validation errors
            return View(reservation);
        }



        public IActionResult Delete(int id)
        {
            var reservation = _reservationRepository.GetReservationById(id);
            if (reservation == null)
                return NotFound();

            return View(reservation);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _reservationRepository.DeleteReservation(id);
            return RedirectToAction("Index", "Admin");
        }
    }
}
