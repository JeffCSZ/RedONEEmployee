using Microsoft.AspNetCore.Mvc;
using RedONEEmployee.Data;

namespace RedONEEmployee.Controllers
{
    public class EmployeeMVCController(MyDBContext _context) : Controller
    {
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }
    }
}
