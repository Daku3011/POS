using EchoPOS.Models;
using EchoPOS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

public class Employee_ShiftsController : Controller
{
    private readonly IEmployee_ShiftsRepository _shiftRepository;
    private readonly IUsersRepository _userRepository;
    private readonly string _connectionString;

    public Employee_ShiftsController(IEmployee_ShiftsRepository shiftRepository, IConfiguration configuration)
    {
        _shiftRepository = shiftRepository;
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    private void PopulateUsersDropdown()
    {
        List<SelectListItem> userList = new List<SelectListItem>();
        Dictionary<int, string> userRoles = new Dictionary<int, string>(); // Store User_Id and Role

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT User_Id, Name, Role FROM Users", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int User_Id = Convert.ToInt32(reader["User_Id"]);
                string Name = reader["Name"].ToString();
                string Role = reader["Role"].ToString();

                userList.Add(new SelectListItem
                {
                    Value = User_Id.ToString(), // Corrected userId to User_Id
                    Text = Name // Corrected userName to Name
                });


                userRoles[User_Id] = Role; // Store User Role
            }
        }

        ViewBag.User_Id = new SelectList(userList, "Value", "Text");
        ViewBag.UserRoles = userRoles; // Store in ViewBag
    }

    public IActionResult Index()
    {
        var shifts = _shiftRepository.GetAllShifts();
        return View(shifts);
    }

    public IActionResult Details(int id)
    {
        var shift = _shiftRepository.GetShiftById(id);
        if (shift == null) return NotFound();
        return View(shift);
    }
    [HttpGet]
    public IActionResult Create()
    {
        PopulateUsersDropdown();
        return View();
    }

    [HttpPost]
    public IActionResult Create(Employee_Shifts shift)
    {
        if (ModelState.IsValid)
        {
            _shiftRepository.AddShift(shift);
            return RedirectToAction("Index", "Admin");
        }
        PopulateUsersDropdown();
        return View(shift);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var shift = _shiftRepository.GetShiftById(id);
        if (shift == null) return NotFound();
        PopulateUsersDropdown();
        return View(shift);
    }

    [HttpPost]
    public IActionResult Edit(Employee_Shifts shift)
    {
        if (ModelState.IsValid)
        {
            _shiftRepository.UpdateShift(shift);
            return RedirectToAction("Index", "Admin");
        }
        PopulateUsersDropdown();
        return View(shift);
    }

    public IActionResult Delete(int id)
    {
        var shift = _shiftRepository.GetShiftById(id);
        if (shift == null) return NotFound();
        return View(shift);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _shiftRepository.DeleteShift(id);
        return RedirectToAction("Index", "Admin");
    }
}
