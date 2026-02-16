using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Infrastructure.Services
{
    /// <summary>
    /// INFRASTRUCTURE LAYER - Concrete implementation of ISalaryCalculator.
    /// 
    /// This could also live in the Application layer depending on your preference.
    /// Here it's in Infrastructure to show that calculation "engines" or external
    /// services can be swapped out without touching the Application or Domain layers.
    /// 
    /// PLACEHOLDER: In a real app, this might call a payroll API or use complex tax rules.
    /// 
    /// PUT A BREAKPOINT here to see the salary calculation logic in action.
    /// </summary>
    public class SalaryCalculator : ISalaryCalculator
    {
        public decimal CalculateNetSalary(Employee employee)
        {
            // PLACEHOLDER: Simple calculation for learning purposes
            // In a real app, this could involve tax tables, pension deductions, etc.

            decimal grossSalary = employee.BaseSalary + employee.Bonus;
            decimal netSalary = grossSalary - employee.Deductions;

            return netSalary;
        }
    }
}
