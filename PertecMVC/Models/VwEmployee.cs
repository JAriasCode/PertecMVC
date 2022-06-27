using System;
using System.Collections.Generic;

namespace PertecMVC.Models
{
    public partial class VwEmployee
    {
        public string IdNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? CurrentJob { get; set; }
        public string? CurrentStatus { get; set; }
    }
}
