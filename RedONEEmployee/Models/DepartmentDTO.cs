namespace RedONEEmployee.Models
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
    }
}
