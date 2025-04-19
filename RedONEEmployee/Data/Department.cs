using System;
using System.Collections.Generic;

namespace RedONEEmployee.Data;

public partial class Department
{
    public string DepartmentName { get; set; } = null!;

    public int Id { get; set; }

    // Navigation Properties
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
