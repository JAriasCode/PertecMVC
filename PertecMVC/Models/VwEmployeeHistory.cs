using System;
using System.Collections.Generic;

namespace PertecMVC.Models
{
    public partial class VwEmployeeHistory
    {
        public string IdNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? OutReason { get; set; }
        public DateTime Date { get; set; }
    }
}
