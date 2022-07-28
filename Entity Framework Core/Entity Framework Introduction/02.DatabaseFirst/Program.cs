using _02.DatabaseFirst.Data;
using _02.DatabaseFirst.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                // 03.Employees Full Information
                //Console.WriteLine(GetEmployeesFullInformation(context));

                // 04.Employees with Salary Over 50 000
                //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

                // 05.Employees from Research and Development
                //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

                // 06.Adding a New Address and Updating Employee
                //Console.WriteLine(AddNewAddressToEmployee(context));

                // 07.Employees and Projects
                //Console.WriteLine(GetEmployeesInPeriod(context));

                // 08.Addresses by Town
                //Console.WriteLine(GetAddressesByTown(context));

                // 09.Employee 147
                //Console.WriteLine(GetEmployee147(context));

                // 10.Departments with More Than 5 Employees
                //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));

                // 11.Find Latest 10 Projects
                //Console.WriteLine(GetLatestProjects(context));

                // 12.Increase Salaries
                //Console.WriteLine(IncreaseSalaries(context));

                // 13.Find Employees by First Name Starting with "Sa"
                //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));

                // 14.Delete Project by Id
                //Console.WriteLine(DeleteProjectById(context));

                // 15.Remove Town
                Console.WriteLine(RemoveTown(context));
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
                    sb.AppendLine($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {(project.EndDate != null ? project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished")}");
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addressess = context.Addresses
                .OrderByDescending(x => x.Employees.Count)
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Select(x => new
                {
                    AddressText = x.AddressText,
                    TownName = x.Town.Name,
                    EmployeeCount = x.Employees.Count
                })
                .Take(10).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addressess)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = context.Projects
                    .Where(p => p.EmployeesProjects
                        .Where(ep => ep.EmployeeId == x.EmployeeId)
                    .Select(ep => ep.ProjectId)
                    .Contains(p.ProjectId))
                    .OrderBy(p => p.Name).ToList()
                })
                .FirstOrDefault();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.Projects)
            {
                sb.AppendLine($"{project.Name}");
            }

            return sb.ToString().Trim();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFullName = x.Manager.FirstName + " " + x.Manager.LastName,
                    Employees = x.Employees
                        .Where(e => e.DepartmentId == x.DepartmentId)
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .Select(e => new
                        {
                            EmployeeFullName = e.FirstName + " " + e.LastName,
                            e.JobTitle
                        })
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFullName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.EmployeeFullName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    x.StartDate
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().Trim();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" }.Contains(x.Department.Name))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12M;
            }

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(x => x.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FullName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().Trim();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {

            var projectToDelete = context.Projects
                .Where(x => x.ProjectId == 2)
                .FirstOrDefault();

            var employeeProjectsToDelete = context.EmployeesProjects
                .Where(x => x.ProjectId == 2)
                .ToList();

            foreach (var employeeProject in employeeProjectsToDelete)
            {
                context.EmployeesProjects.Remove(employeeProject);
            }

            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

            var projects = context.Projects
                .Select(x => x.Name)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project}");
            }

            return sb.ToString().Trim();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            string townName = "Seattle";

            var townToDelete = context.Towns
                .Where(x => x.Name == townName)
                .FirstOrDefault();

            var addressessToDelete = context.Addresses
                .Where(x => x.TownId == townToDelete.TownId)
                .ToList();

            var employees = context.Employees
                .Where(x => addressessToDelete.Select(a => a.AddressId).ToList().Contains((int)x.AddressId))
                .ToList();

            foreach(var employee in employees)
            {
                employee.AddressId = null;
            }

            string result = $"{addressessToDelete.Count} addresses in {townName} were deleted";

            foreach(var address in addressessToDelete)
            {
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(townToDelete);

            context.SaveChanges();

            return result;
        }
    }
}
