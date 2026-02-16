using System;
using System.Windows.Forms;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;

namespace WindowsFormsApp1
{
    /// <summary>
    /// UI / PRESENTATION LAYER - The outermost layer of Clean Architecture.
    /// 
    /// NOTICE: This form only knows about ISalaryService (an interface from Application layer).
    /// It does NOT know about:
    ///   - Domain entities (Employee entity)
    ///   - Infrastructure (FakeEmployeeRepository, SalaryCalculator)
    ///   - Database details, file I/O, etc.
    /// 
    /// The form receives its dependency (ISalaryService) via constructor injection.
    /// This is the Dependency Inversion Principle in action.
    /// 
    /// PUT A BREAKPOINT on btnCalculateSalary_Click to start your debugging journey.
    /// Then Step Into (F11) to follow the flow through all layers.
    /// </summary>
    public partial class Employee : Form
    {
        private readonly ISalaryService _salaryService;

        // Constructor receives the service via Dependency Injection
        // The form has NO idea which concrete class implements ISalaryService
        public Employee(ISalaryService salaryService)
        {
            InitializeComponent();
            _salaryService = salaryService;
        }

        private void btnCalculateSalary_Click(object sender, EventArgs e)
        {
            // STEP 0 (UI Layer): User clicks button -> we read the textbox
            // PUT BREAKPOINT HERE -> then press F11 to step into the Application layer

            if (!int.TryParse(txtEmplyeeNumber.Text, out int empNumber))
            {
                lblSalary.Text = "Please enter a valid employee number (try 101-105).";
                return;
            }

            try
            {
                // STEP 1: Call the Application layer service
                // The UI only talks to the Application layer, never to Infrastructure or Domain directly
                SalaryResultDto result = _salaryService.GetEmployeeSalary(empNumber);

                // STEP 4 (back in UI): Display the result from the DTO
                lblSalary.Text =
                    $"Employee #: {result.EmployeeNumber}\n" +
                    $"Name: {result.EmployeeName}\n" +
                    $"Department: {result.Department}\n" +
                    $"Base Salary: {result.BaseSalary:C}\n" +
                    $"Bonus: {result.Bonus:C}\n" +
                    $"Deductions: {result.Deductions:C}\n" +
                    $"NET SALARY: {result.NetSalary:C}";
            }
            catch (Exception ex)
            {
                lblSalary.Text = $"Error: {ex.Message}";
            }
        }
    }
}
