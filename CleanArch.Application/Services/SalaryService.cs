using System;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    /// <summary>
    /// APPLICATION LAYER - Use Case / Service Implementation
    /// 
    /// THIS IS WHERE THE MAGIC OF CLEAN ARCHITECTURE HAPPENS:
    /// - This class depends on IEmployeeRepository (defined in Domain)
    /// - It does NOT depend on the actual database implementation
    /// - It orchestrates the flow: fetch employee → calculate salary → return DTO
    /// 
    /// PUT A BREAKPOINT HERE to see how the UI calls this service,
    /// and how this service calls the repository through the interface.
    /// </summary>
    public class SalaryService : ISalaryService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISalaryCalculator _salaryCalculator;

        // Constructor Injection - dependencies are passed in, not created here
        public SalaryService(IEmployeeRepository employeeRepository, ISalaryCalculator salaryCalculator)
        {
            _employeeRepository = employeeRepository;
            _salaryCalculator = salaryCalculator;
        }

        public SalaryResultDto GetEmployeeSalary(int employeeNumber)
        {
            // STEP 1: Fetch employee from repository (could be DB, file, API - we don't care here)
            // PUT BREAKPOINT HERE → then Step Into (F11) to see it go to Infrastructure layer
            Employee employee = _employeeRepository.GetByEmployeeNumber(employeeNumber);

            if (employee == null)
            {
                throw new Exception($"Employee with number {employeeNumber} not found.");
            }

            // STEP 2: Calculate net salary using the domain service
            // PUT BREAKPOINT HERE → then Step Into (F11) to see calculation logic
            decimal netSalary = _salaryCalculator.CalculateNetSalary(employee);

            // STEP 3: Map domain entity to DTO (what the UI layer will receive)
            // Notice: UI never sees the domain Employee entity directly
            var result = new SalaryResultDto
            {
                EmployeeNumber = employee.EmployeeNumber,
                EmployeeName = employee.Name,
                Department = employee.Department,
                BaseSalary = employee.BaseSalary,
                Bonus = employee.Bonus,
                Deductions = employee.Deductions,
                NetSalary = netSalary
            };

            return result;
        }
    }
}
