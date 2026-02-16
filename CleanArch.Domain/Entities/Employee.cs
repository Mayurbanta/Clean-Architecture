namespace CleanArch.Domain.Entities
{
    /// <summary>
    /// Domain Entity - represents the core Employee business object.
    /// This is the innermost layer. It has NO dependencies on any other project.
    /// </summary>
    public class Employee
    {
        public int EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }
    }
}
