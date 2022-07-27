﻿using System;
using System.Collections.Generic;

namespace _02.DatabaseFirst.Data.Models
{
    public partial class Project
    {
        public Project()
        {
            EmployeesProjects = new HashSet<EmployeesProjects>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<EmployeesProjects> EmployeesProjects { get; set; }
    }
}
