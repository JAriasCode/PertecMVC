namespace PertecMVC.Models.Custom
{
    public class CustomJob: Job
    {
        public IEnumerable<Job>? JobList { get; set; }

        public Job GetJob()
        {
            return new Job
            {
                Description = Description,
            };
        }
    }
}
