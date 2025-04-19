using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedONEEmployee.Data;

public partial class Employee
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string EmployeeId { get; set; } = null!;
    [MaxLength(50)]
    public string EmployeeName { get; set; } = null!;

    // FK to DepartmentId
    public int DepartmentId { get; set; }

    // Navigation Properties back to department
    public virtual Department Department { get; set; } = null!;
}
