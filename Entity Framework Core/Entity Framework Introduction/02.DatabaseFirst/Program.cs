using _02.DatabaseFirst.Data;
using _02.DatabaseFirst.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                // 02.Employees Full Information
                //Console.WriteLine(GetEmployeesFullInformation(context));

                // 03.Employees with Salary Over 50 000
                //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

                // 04.Employees from Research and Development
                Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            IReadOnlyCollection<Employee> employees = context.Employees
                .Select(x => new Employee
                {
                    EmployeeId = x.EmployeeId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MiddleName = x.MiddleName,
                    JobTitle = x.JobTitle,
                    Salary = x.Salary
                })
                .OrderBy(x => x.EmployeeId).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            IReadOnlyCollection<Employee> employees = context.Employees
                .Where(x => x.Salary > 50000)
                .Select(x => new Employee
                {
                    FirstName = x.FirstName,
                    Salary = x.Salary
                })
                .OrderBy(x => x.FirstName).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x=>x.Department.Name == "Research and Development")
                .Select(x=> new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DepartmentName = x.Department.Name,
                    Salary = x.Salary
                })
                .OrderBy(x => x.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            return sb.ToString().Trim();
        }
    }
}
