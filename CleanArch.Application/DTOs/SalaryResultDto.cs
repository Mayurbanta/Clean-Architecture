namespace CleanArch.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object - carries data between layers.
    /// The UI layer will receive this, NOT the domain entity directly.
    /// This keeps the domain model hidden from the presentation layer.
    /// </summary>
    public class SalaryResultDto
    {
        public int EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetSalary { get; set; }
    }
}
