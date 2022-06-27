using System;
using System.Collections.Generic;

namespace PertecMVC.Models
{
    public partial class VwEmployeeJob
    {
        public string IdNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? JobDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
