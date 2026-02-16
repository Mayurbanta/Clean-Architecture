using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    /// <summary>
    /// Domain Service Interface - defines the contract for salary calculation.
    /// The actual calculation logic will live in the Application layer.
    /// </summary>
    public interface ISalaryCalculator
    {
        decimal CalculateNetSalary(Employee employee);
    }
}
