using PertecMVC.Globals;

namespace PertecMVC.Models.Custom
{
    public class CustomEmployee: Employee
    {
        public string? OutReason { get; set; }
        public IEnumerable<VwEmployee>? EmployeeList { get; set; }
        public IEnumerable<Job>? JobList { get; set; }
        public IEnumerable<Status>? StatusList { get; set; }

        public Employee GetEmployee()
        {
            return new Employee
            {
                IdNumber = IdNumber,
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                Address = Address,
                CurrentJob = CurrentJob,
                CurrentStatus = CurrentStatus,
            };
        }

        public EmployeeInOut GetEmployeeIn()
        {
            return new EmployeeInOut
            {
                EmployeeIdNumber = IdNumber,
                Type = InOutTypes.EmployeeIn,
                Date = DateTime.Now,
            };
        }

        public EmployeeInOut GetEmployeeOut()
        {
            return new EmployeeInOut
            {
                EmployeeIdNumber = IdNumber,
                Type = InOutTypes.EmployeeOut,
                OutReason = OutReason,
                Date = DateTime.Now,
            };
        }

        public JobHistory GetJobHistory()
        {
            return new JobHistory
            {
                JobId = CurrentJob,
                EmployeeIdNumber = IdNumber,
                StartDate = DateTime.Now,
            };
        }

        public void SetEmployeeData(Employee employee, IEnumerable<Job> jobList, IEnumerable<Status> statusList)
        {
            JobList = jobList;
            StatusList = statusList;
            IdNumber = employee.IdNumber;
            FirstName = employee.FirstName;
            MiddleName = employee.MiddleName;
            LastName = employee.LastName;
            PhoneNumber = employee.PhoneNumber;
            Email = employee.Email;
            Address = employee.Address;
            CurrentJob = employee.CurrentJob;
            CurrentStatus = employee.CurrentStatus;
        }

    }
}
 