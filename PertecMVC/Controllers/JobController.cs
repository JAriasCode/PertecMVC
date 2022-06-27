using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using PertecMVC.Models;
using PertecMVC.Models.Custom;

namespace PertecMVC.Controllers
{
    public class JobController : Controller
    {

        private readonly PERTECDBContext _context;
        private readonly ILogger<JobController> _logger;
        private readonly INotyfService _notyf;

        public JobController(ILogger<JobController> logger, PERTECDBContext context, INotyfService notyf)
        {
            _logger = logger;
            _context = context;
            _notyf = notyf;
        }

        #region Views
        public IActionResult Index()
        {
            CustomJob customJob = new CustomJob();

            customJob.JobList = _context.Jobs.ToList();

            return View(customJob);
        }

        #endregion

        #region Actions
        [HttpPost]
        public IActionResult Add(Job job)
        {
            try
            {
                _context.Jobs.Add(job);

                _context.SaveChanges();

                _notyf.Success("Trabajo agregado con éxito");
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                //Validates if exists a job history of that job so it cannot be deleted
                if(!_context.JobHistories.Any(x => x.JobId == id))
                {
                    Job job = _context.Jobs.Where(x => x.Id == id).FirstOrDefault()!;

                    _context.Jobs.Remove(job);

                    _context.SaveChanges();

                    _notyf.Success("Trabajo eliminado con éxito");
                }
                else
                {
                    _notyf.Error("Alguien ya ha tenido este puesto, no se puede eliminar");
                }
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
            }

            return RedirectToAction("Index");

        }

        #endregion
    }
}
