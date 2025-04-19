using Microsoft.AspNetCore.Mvc;

namespace RedONEEmployee.Controllers
{
    public class EmployeeMVCController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
