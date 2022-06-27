using System;
using System.Collections.Generic;

namespace PertecMVC.Models
{
    public partial class EmployeeInOut
    {
        public int Id { get; set; }
        public string EmployeeIdNumber { get; set; } = null!;
        public string Type { get; set; } = null!;
        public DateTime Date { get; set; }
        public string? OutReason { get; set; }

        public virtual Employee EmployeeIdNumberNavigation { get; set; } = null!;
    }
}
