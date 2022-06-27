namespace PertecMVC.Models.Custom
{
    public class CustomEmployeeInOuts: EmployeeInOut
    {
        public IEnumerable<VwEmployeeHistory>? InOutList { get; set; }

    }
}
