using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedONEEmployee.Data;
using RedONEEmployee.Models;

namespace RedONEEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(MyDBContext _context, ILogger<EmployeeController> _logger) : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAllEmployee()
        {
            //var employee = _context.Employees.ToList();
            //return Ok(employee);
            // use Entity Framework to call Store Proc

            // Serilog
            _logger.Log(LogLevel.Error, "Error Message");
            _logger.Log(LogLevel.Information, "Information Message");
            _logger.Log(LogLevel.Warning, "Warning Message");
            var employees = _context.Database.SqlQueryRaw<EmployeeDTO2>("EXEC sp_GetAllEmployees").ToList();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(EmployeeDTO employeeDTO)
        {
            // Call the stored procedure
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_AddEmployee" +
                " @EmployeeId = {0}, @EmployeeName = {1}, @DepartmentId = {2}"
                , employeeDTO.EmployeeId, employeeDTO.EmployeeName, employeeDTO.DepartmentId);

            return Ok();
        }

        [HttpGet("GetEmployeeWithDepartmentName")]
        public ActionResult GetEmployeeWithDepartmentName()
        {
            //var employee = _context.Employees.ToList();
            //return Ok(employee);
            // use Entity Framework to call Store Proc
            var employees = _context.Database.SqlQueryRaw<EmployeeDTO>("EXEC sp_GetAllEmployeesWithDepartmentName").ToList();
            return Ok(employees);
        }
    }
}
