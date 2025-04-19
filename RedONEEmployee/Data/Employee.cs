using System;
using System.Collections.Generic;

namespace RedONEEmployee.Data;

public partial class Employee
{
    public int Id { get; set; }

    public string EmployeeId { get; set; } = null!;

    public string EmployeeName { get; set; } = null!;

    // FK to DepartmentId
    public int DepartmentId { get; set; }

    // Navigation Properties back to department
    public virtual Department Department { get; set; } = null!;
}
