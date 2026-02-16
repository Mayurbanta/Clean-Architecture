using System.Collections.Generic;
using System.Linq;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Infrastructure.Repositories
{
    /// <summary>
    /// INFRASTRUCTURE LAYER - Concrete implementation of IEmployeeRepository.
    /// 
    /// In a real app, this would hit a SQL database, call an API, read a file, etc.
    /// Here we use an in-memory list of fake employees so you can debug the flow.
    /// 
    /// KEY INSIGHT: This class implements the interface defined in the DOMAIN layer.
    /// The Domain layer never references this project. This is Dependency Inversion.
    /// 
    /// PUT A BREAKPOINT on GetByEmployeeNumber() to see the flow arrive here
    /// from the Application layer's SalaryService.
    /// </summary>
    public class FakeEmployeeRepository : IEmployeeRepository
    {
        // PLACEHOLDER: In a real app, this would be a database connection
        private readonly List<Employee> _employees = new List<Employee>
        {
            new Employee { EmployeeNumber = 101, Name = "Rahul Sharma",   Department = "Engineering", BaseSalary = 75000m, Bonus = 5000m, Deductions = 3000m },
            new Employee { EmployeeNumber = 102, Name = "Priya Patel",    Department = "HR",          BaseSalary = 65000m, Bonus = 4000m, Deductions = 2500m },
            new Employee { EmployeeNumber = 103, Name = "Amit Kumar",     Department = "Finance",     BaseSalary = 80000m, Bonus = 6000m, Deductions = 4000m },
            new Employee { EmployeeNumber = 104, Name = "Sneha Reddy",    Department = "Engineering", BaseSalary = 90000m, Bonus = 8000m, Deductions = 5000m },
            new Employee { EmployeeNumber = 105, Name = "Vikram Singh",   Department = "Marketing",   BaseSalary = 60000m, Bonus = 3000m, Deductions = 2000m },
        };

        public Employee GetByEmployeeNumber(int employeeNumber)
        {
            // PLACEHOLDER: In a real app, this would be something like:
            // return _dbContext.Employees.FirstOrDefault(e => e.EmployeeNumber == employeeNumber);
            // or a raw SQL query, or an API call, etc.

            return _employees.FirstOrDefault(e => e.EmployeeNumber == employeeNumber);
        }
    }
}
