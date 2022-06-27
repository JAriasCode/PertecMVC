using System;
using System.Collections.Generic;

namespace PertecMVC.Models
{
    public partial class JobHistory
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string EmployeeIdNumber { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Employee EmployeeIdNumberNavigation { get; set; } = null!;
        public virtual Job Job { get; set; } = null!;
    }
}
