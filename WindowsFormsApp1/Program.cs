using System;
using System.Windows.Forms;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Repositories;
using CleanArch.Infrastructure.Services;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// COMPOSITION ROOT - This is where ALL dependencies are wired together.
        /// 
        /// In Clean Architecture, the outermost layer (UI) is responsible for
        /// creating concrete implementations and injecting them.
        /// 
        /// In a real enterprise app, you'd use a DI container (e.g., Autofac, Unity).
        /// Here we do "Poor Man's DI" (manual wiring) so you can see every step clearly.
        /// 
        /// PUT A BREAKPOINT HERE to see how objects are created and injected.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // === DEPENDENCY WIRING (Composition Root) ===

            // 1. Create Infrastructure implementations (the outermost layer knows about these)
            IEmployeeRepository employeeRepository = new FakeEmployeeRepository();
            ISalaryCalculator salaryCalculator = new SalaryCalculator();

            // 2. Create Application layer service, injecting the infrastructure dependencies
            ISalaryService salaryService = new SalaryService(employeeRepository, salaryCalculator);

            // 3. Create the Form (UI), injecting the application service
            //    The Form only knows about ISalaryService — it has no idea about repositories or calculators
            Employee employeeForm = new Employee(salaryService);

            Application.Run(employeeForm);
        }
    }
}
