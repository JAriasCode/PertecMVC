using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using PertecMVC.Models;
using PertecMVC.Models.Custom;

namespace PertecMVC.Controllers
{
    public class EmployeeJobController : Controller
    {

        private readonly PERTECDBContext _context;
        private readonly ILogger<EmployeeJobController> _logger;
        private readonly INotyfService _notyf;

        public EmployeeJobController(ILogger<EmployeeJobController> logger, PERTECDBContext context, INotyfService notyf)
        {
            _logger = logger;
            _context = context;
            _notyf = notyf;
        }

        #region Views
        public IActionResult Index(string employeeIdNumber)
        {
            CustomJobHistory customJobHistory = new()
            {
                JobList = _context.VwEmployeeJobs.Where(x => x.IdNumber.Equals(employeeIdNumber)).ToList(),
            };

            return View(customJobHistory);
        }

        #endregion
    }
}
