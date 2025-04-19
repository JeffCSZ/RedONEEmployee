using RedONEEmployee.Data;
using System.ComponentModel.DataAnnotations;

namespace RedONEEmployee.Models
{
    public class EmployeeDTO
    {
        [MaxLength(50)]
        public string EmployeeId { get; set; } = null!;
        [MaxLength(50)]
        public string EmployeeName { get; set; } = null!;

        // FK to DepartmentId
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } // Flatten Department details
    }
}
