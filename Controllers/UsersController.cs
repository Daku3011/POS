using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EchooPays.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository _userRepository;

        public UsersController(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Users> users = _userRepository.GetAllUsers();
            return View(users);
        }

        public IActionResult Details(int id)
        {
            Users user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Users user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.AddUser(user);
                return RedirectToAction("Index", "Admin");
            }
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            Users user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(Users user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.UpdateUser(user);
                return RedirectToAction("Index", "Admin");
            }
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            Users user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _userRepository.DeleteUser(id);
            return RedirectToAction("Index", "Admin");
        }
    }
}
