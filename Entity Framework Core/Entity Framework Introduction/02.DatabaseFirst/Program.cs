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
                //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

                // 05.Adding a New Address and Updating Employee
                //Console.WriteLine(AddNewAddressToEmployee(context));

                // 06.Employees and Projects
                Console.WriteLine(GetEmployeesInPeriod(context));
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
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new
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

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee employee = context.Employees.Where(x => x.LastName == "Nakov").FirstOrDefault();

            if (employee == null)
            {
                throw new ArgumentNullException("No such employee!");
            }

            employee.Address = newAddress;

            context.SaveChanges();

            var addresses = context.Employees.OrderByDescending(x => x.AddressId).Take(10).Select(e => e.Address.AddressText).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine(address);
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var projectIDs = context.Projects.Where(x => x.StartDate.Year >= 2001 && x.StartDate.Year <= 2003).Select(x => x.ProjectId).ToList();
            var employeeIDs = context.EmployeesProjects.Where(x => projectIDs.Contains(x.ProjectId)).Select(x => x.EmployeeId).ToList();
            var employees = context.Employees.Where(x => employeeIDs.Contains(x.EmployeeId)).Take(10).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                var manager = context.Employees.Where(x => x.EmployeeId == employee.ManagerId).FirstOrDefault();
                var employeeProjectIDs = context.EmployeesProjects.Where(x => x.EmployeeId == employee.EmployeeId).Select(x => x.ProjectId).ToList();
                var employeeProjects = context.Projects.Where(x => employeeProjectIDs.Contains(x.ProjectId)).ToList();
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {manager.FirstName} {manager.LastName}");

                foreach (var project in employeeProjects)
                {
                    sb.AppendLine($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - {(project.EndDate != null ? project.StartDate.ToString("M/d/yyyy h:mm:ss tt") : "not finished")}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
