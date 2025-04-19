using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RedONEEmployee.Data;

public partial class Department
{
    [MaxLength(50)]
    public string DepartmentName { get; set; } = null!;

    public int Id { get; set; }

    // Navigation Properties
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
