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
                Console.WriteLine(GetEmployeesFullInformation(context)); ;
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            IReadOnlyCollection<Employee> employees = context.Employees.OrderBy(x => x.EmployeeId).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().Trim();
        }
    }
}
