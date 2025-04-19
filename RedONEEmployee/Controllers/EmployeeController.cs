using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedONEEmployee.Data;

namespace RedONEEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(MyDBContext _context) : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAllEmployee()
        {
            var employee = _context.Employees.ToList();
            return Ok(employee);
        }
    }
}
