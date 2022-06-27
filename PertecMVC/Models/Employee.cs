using System;
using System.Collections.Generic;

namespace PertecMVC.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeInOuts = new HashSet<EmployeeInOut>();
            JobHistories = new HashSet<JobHistory>();
        }

        public string IdNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int CurrentJob { get; set; }
        public int CurrentStatus { get; set; }

        public virtual Job CurrentJobNavigation { get; set; } = null!;
        public virtual ICollection<EmployeeInOut> EmployeeInOuts { get; set; }
        public virtual ICollection<JobHistory> JobHistories { get; set; }
    }
}
