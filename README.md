# Clean Architecture Demo — Employee Salary Calculator

A .NET Framework 4.8 Windows Forms application structured using **Clean Architecture** principles.
Built for learning how separation of concerns and dependency inversion work in practice.

---

## The One Rule to Remember

> **Dependencies always point inward. Inner layers never know about outer layers.**

```
UI  →  Application  →  Domain  ←  Infrastructure
```

- **Domain** depends on **NOTHING** (it's the center)
- **Application** depends on **Domain only**
- **Infrastructure** depends on **Domain only**
- **UI** wires everything together at startup

---

## Each Layer in One Sentence

| Layer | One-Liner | What Goes Here | What NEVER Goes Here |
|---|---|---|---|
| **Domain** | The business vocabulary | Entities, Interfaces (contracts) | Database code, UI code, any external dependency |
| **Application** | The business workflow | Use cases, Services, DTOs, Business logic | Database calls, HTTP calls, file I/O |
| **Infrastructure** | The outside world adapter | Repositories (DB), API clients, File I/O, Email | Business rules, UI code |
| **UI** | The user's window | Forms, Controllers, Views | Business logic, direct DB calls |

---

## Easy Memory Aid: "The Restaurant Analogy"

```
Domain         = The MENU (defines what dishes exist and what ingredients they need)
Application    = The CHEF (follows recipes, orchestrates cooking, decides the order)
Infrastructure = The KITCHEN SUPPLIES (fridge, oven, delivery — provides raw materials)
UI             = The WAITER (takes order from customer, delivers food, knows nothing about cooking)
Program.cs     = The RESTAURANT MANAGER (hires the chef, sets up the kitchen, assigns the waiter)
```

- The **Menu** doesn't care who cooks or how supplies arrive
- The **Chef** follows the menu but doesn't care if ingredients come from a farm or a supermarket
- The **Kitchen Supplies** fulfill what the menu requires but don't decide what to cook
- The **Waiter** just talks to the chef and delivers results to the customer

---

## Solution Structure

```
MyUI/
├── MySolution.sln
│
├── CleanArch.Domain/                          ← INNERMOST (no dependencies)
│   ├── Entities/
│   │   └── Employee.cs                        ← Domain entity (core business object)
│   └── Interfaces/
│       ├── IEmployeeRepository.cs             ← Contract: "I need employee data"
│       └── ISalaryCalculator.cs               ← Contract: "I need salary calculation"
│
├── CleanArch.Application/                     ← BUSINESS LOGIC (depends only on Domain)
│   ├── DTOs/
│   │   └── SalaryResultDto.cs                 ← Data shape for the UI (not the raw entity)
│   ├── Interfaces/
│   │   └── ISalaryService.cs                  ← Contract: what the UI can call
│   └── Services/
│       └── SalaryService.cs                   ← THE ORCHESTRATOR: fetch → calculate → return
│
├── CleanArch.Infrastructure/                  ← EXTERNAL WORLD (depends only on Domain)
│   ├── Repositories/
│   │   └── FakeEmployeeRepository.cs          ← Implements IEmployeeRepository (fake DB)
│   └── Services/
│       └── SalaryCalculator.cs                ← Implements ISalaryCalculator
│
└── WindowsFormsApp1/                          ← UI (outermost)
    ├── Employee.cs                            ← Form — only knows ISalaryService
    ├── Employee.Designer.cs                   ← TextBox, Button, Label
    └── Program.cs                             ← COMPOSITION ROOT (wires everything)
```

---

## Dependency Diagram

```
┌──────────────────────────────────────────────────────┐
│  UI (WindowsFormsApp1)                               │
│    ┌──────────────────────────────────────────────┐   │
│    │  Infrastructure                              │   │
│    │    ┌──────────────────────────────────────┐   │   │
│    │    │  Application                         │   │   │
│    │    │    ┌──────────────────────────────┐   │   │   │
│    │    │    │  Domain (innermost)          │   │   │   │
│    │    │    │  - Entities                  │   │   │   │
│    │    │    │  - Interfaces                │   │   │   │
│    │    │    └──────────────────────────────┘   │   │   │
│    │    └──────────────────────────────────────┘   │   │
│    └──────────────────────────────────────────────┘   │
└──────────────────────────────────────────────────────┘
```

---

## Request Flow (What Happens When You Click the Button)

```
STEP 1  [UI]             btnCalculateSalary_Click()  → reads textbox, calls ISalaryService
   |
STEP 2  [Application]    SalaryService.GetEmployeeSalary()  → orchestrates the work
   |
STEP 3  [Infrastructure] FakeEmployeeRepository.GetByEmployeeNumber()  → returns employee data
   |
STEP 4  [Infrastructure] SalaryCalculator.CalculateNetSalary()  → does the math
   |
STEP 5  [Application]    Maps result to SalaryResultDto  → returns to UI
   |
STEP 6  [UI]             Displays result in lblSalary
```

---

## Composition Root (Program.cs) — Where Dependencies Are Wired

```csharp
// 1. Create Infrastructure (the "kitchen supplies")
IEmployeeRepository employeeRepository = new FakeEmployeeRepository();
ISalaryCalculator salaryCalculator = new SalaryCalculator();

// 2. Create Application service (the "chef"), give it the supplies
ISalaryService salaryService = new SalaryService(employeeRepository, salaryCalculator);

// 3. Create Form (the "waiter"), give it the chef
Employee employeeForm = new Employee(salaryService);
```

This is the **ONLY place** that knows about all concrete classes. Swap `FakeEmployeeRepository` for `SqlEmployeeRepository` here — nothing else changes.

---

## The Golden Test

> *"If I delete the entire Infrastructure project and create a new one with a real database, what else needs to change?"*

**Answer: Only `Program.cs`.** Domain, Application, and the Form stay untouched. That's the power of Clean Architecture.

---

## Common Mistakes to Avoid

| Mistake | Why It's Wrong |
|---|---|
| Calling repository directly from UI | UI should only talk to Application layer |
| Putting business logic in Infrastructure | Infrastructure is for external I/O only (DB, API, files) |
| Infrastructure classes calling each other | Let Application orchestrate, not Infrastructure |
| Domain referencing any other project | Domain is the center — it references NOTHING |
| Skipping DTOs and returning entities to UI | UI should never see raw domain objects |

---

## What Goes Where — Quick Decision Guide

Ask yourself these questions:

1. **Is it a core business object or rule?** → **Domain**
2. **Is it a workflow / use case / orchestration?** → **Application**
3. **Does it talk to a database, API, file, or external service?** → **Infrastructure**
4. **Does it show something to the user or read user input?** → **UI**
5. **Is it pure calculation with no I/O?** → **Application** (or Domain if it's a core rule)

---

## Sample Data

The `FakeEmployeeRepository` contains 5 hardcoded employees (try 101–105):

| Employee # | Name | Department | Base Salary | Bonus | Deductions |
|---|---|---|---|---|---|
| 101 | Rahul Sharma | Engineering | 75,000 | 5,000 | 3,000 |
| 102 | Priya Patel | HR | 65,000 | 4,000 | 2,500 |
| 103 | Amit Kumar | Finance | 80,000 | 6,000 | 4,000 |
| 104 | Sneha Reddy | Engineering | 90,000 | 8,000 | 5,000 |
| 105 | Vikram Singh | Marketing | 60,000 | 3,000 | 2,000 |

---

## How to Debug (Step-by-Step)

1. Open `MySolution.sln` in Visual Studio
2. Set breakpoints at:
   - **Program.cs** → `Main()` — See dependency wiring
   - **Employee.cs** → `btnCalculateSalary_Click` — UI entry point
   - **SalaryService.cs** → `GetEmployeeSalary` — Application orchestration
   - **FakeEmployeeRepository.cs** → `GetByEmployeeNumber` — Data access
   - **SalaryCalculator.cs** → `CalculateNetSalary` — Calculation
3. Press **F5**, enter employee number **101–105**, click "Calculate Salary"
4. Use **F11 (Step Into)** to follow the flow across layers

---

## Technology Stack

- **.NET Framework 4.8**
- **Windows Forms** (WinForms)
- **C#**
- **Visual Studio 2019**
