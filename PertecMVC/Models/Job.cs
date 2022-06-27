using System;
using System.Collections.Generic;

namespace PertecMVC.Models
{
    public partial class Job
    {
        public Job()
        {
            Employees = new HashSet<Employee>();
            JobHistories = new HashSet<JobHistory>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<JobHistory> JobHistories { get; set; }
    }
}
