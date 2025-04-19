using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedONEEmployee.Data;
using RedONEEmployee.Models;

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

        [HttpGet("GetDepartmentWithEmployee")]
        public ActionResult GetDepartmentWithEmployee()
        {
            var deptWithEmployees = _context.Departments
                .Include(d => d.Employees)
                .ToList();
            return Ok(deptWithEmployees);
        }

        [HttpGet("GetDepartmentWithEmployeeWithDepartmentName")]
        public async Task<ActionResult> GetDepartmentWithEmployeeWithDepartmentName()
        {
            var departmentsWithEmployees = await _context.Departments
            .Include(d => d.Employees)
            .Select(d => new DepartmentDto
            {
                Id = d.Id,
                DepartmentName = d.DepartmentName,
                Employees = d.Employees.Select(e => new EmployeeDTO
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.EmployeeName,
                    DepartmentId = e.DepartmentId,
                    DepartmentName = e.Department.DepartmentName // Access Department directly
                }).ToList()
            })
            .ToListAsync();
            return Ok(departmentsWithEmployees);
        }
    }
}
