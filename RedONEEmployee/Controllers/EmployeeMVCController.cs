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

        public IActionResult GetEmployeeByID(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            return View(employee);
        }

        public IActionResult GetEmployeeByID2(int id)
        {
            return View(id);
        }
    }
}
