using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    /// <summary>
    /// Repository Interface - defined in Domain layer.
    /// The IMPLEMENTATION lives in Infrastructure, but the CONTRACT lives here.
    /// This is the key to Dependency Inversion Principle (DIP).
    /// Domain never knows about databases, files, or APIs.
    /// </summary>
    public interface IEmployeeRepository
    {
        Employee GetByEmployeeNumber(int employeeNumber);
    }
}
