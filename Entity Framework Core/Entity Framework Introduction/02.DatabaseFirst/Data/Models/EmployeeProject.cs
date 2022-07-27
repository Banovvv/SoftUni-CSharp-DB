using System;
using System.Collections.Generic;

namespace _02.DatabaseFirst.Data.Models
{
    public partial class EmployeesProjects
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
    }
}
