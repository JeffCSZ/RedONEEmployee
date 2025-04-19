using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedONEEmployee.Data;

namespace RedONEEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(MyDBContext _context) : ControllerBase
    {
        [HttpGet("GetAllDepartments")]
        public ActionResult GetAllDepartments()
        {
            var depts = _context.Departments.ToList();
            return Ok(depts);
        }

        // From Route
        [HttpGet("GetDepartment/{id:int}")]
        public ActionResult GetDepartment(int id)
        {
            var dept = _context.Departments.FirstOrDefault(d => d.Id == id);
            return Ok(dept);
        }

        // From Query
        [HttpGet("GetDepartment2")]
        public ActionResult GetDepartment2(int id)
        {
            var dept = _context.Departments.FirstOrDefault(d => d.Id == id);
            return Ok(dept);
        }
    }
}
