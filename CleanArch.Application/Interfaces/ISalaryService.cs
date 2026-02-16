using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces
{
    /// <summary>
    /// Application Service Interface - defines what the UI layer can call.
    /// The UI only knows about this interface, not the implementation.
    /// </summary>
    public interface ISalaryService
    {
        SalaryResultDto GetEmployeeSalary(int employeeNumber);
    }
}
