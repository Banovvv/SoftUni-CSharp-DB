﻿namespace _02.DatabaseFirst.Data.Models
{
    public partial class DeletedEmployee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string JobTitle { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
    }
}
