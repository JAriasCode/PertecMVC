namespace PertecMVC.Models.Custom
{
    public class CustomJobHistory: JobHistory
    {
        public IEnumerable<VwEmployeeJob>? JobList { get; set; }

    }
}
