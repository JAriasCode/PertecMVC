using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using PertecMVC.Models;
using PertecMVC.Models.Custom;

namespace PertecMVC.Controllers
{
    public class EmployeeHistoryController : Controller
    {
        private readonly PERTECDBContext _context;
        private readonly ILogger<EmployeeHistoryController> _logger;
        private readonly INotyfService _notyf;
        public EmployeeHistoryController(ILogger<EmployeeHistoryController> logger, PERTECDBContext context, INotyfService notyf)
        {
            _logger = logger;
            _context = context;
            _notyf = notyf;
        }

        #region Views
        public IActionResult Index()
        {
            CustomEmployeeInOuts customEmployeeInOuts = new CustomEmployeeInOuts();

            customEmployeeInOuts.InOutList = _context.VwEmployeeHistories.ToList();

            return View(customEmployeeInOuts);
        }

        #endregion
    }
}
