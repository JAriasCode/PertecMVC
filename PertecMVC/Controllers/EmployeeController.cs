using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PertecMVC.Globals;
using PertecMVC.Models;
using PertecMVC.Models.Custom;
using System.Diagnostics;

namespace PertecMVC.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly PERTECDBContext _context;
        private readonly ILogger<EmployeeController> _logger;
        private readonly INotyfService _notyf;

        private bool isOk = true;

        public EmployeeController(ILogger<EmployeeController> logger, PERTECDBContext context, INotyfService notyf)
        {
            _logger = logger;
            _context = context;
            _notyf = notyf;
        }

        #region Views
        public IActionResult Index()
        {

            CustomEmployee customEmployee = new()
            {
                EmployeeList = _context.VwEmployees.ToList(),
            };

            return View(customEmployee);
        }

        public IActionResult Add(CustomEmployee? customEmployee)
        {
            customEmployee = new()
            {
                JobList = _context.Jobs.ToList(),
                StatusList = _context.Statuses.ToList()
            };

            return View(customEmployee);
        }

        public IActionResult Edit(string idNumber)
        {
            CustomEmployee customEmployee = new CustomEmployee();

            Employee employee = _context.Employees.Where(x => x.IdNumber.Equals(idNumber)).FirstOrDefault()!;

            customEmployee.SetEmployeeData(employee, _context.Jobs.ToList(), _context.Statuses.ToList());

            return View(customEmployee);
        }

        #endregion

        #region Actions
        [HttpPost]
        public async Task<IActionResult> AddEmployee(CustomEmployee customEmployee)
        {
            try
            {
                if (!_context.Employees.Any(x => x.IdNumber.Equals(customEmployee.IdNumber)))
                {

                    customEmployee.CurrentStatus = (int)Globals.Status.InCompany;

                    await _context.Employees.AddAsync(customEmployee.GetEmployee());

                    await _context.EmployeeInOuts.AddAsync(customEmployee.GetEmployeeIn());

                    await _context.JobHistories.AddAsync(customEmployee.GetJobHistory());

                    await _context.SaveChangesAsync();

                    _notyf.Success("Empleado guardado con éxito");

                    return RedirectToAction("Index");

                }
                else
                {
                    _notyf.Error("El empleado ya existe en el sistema");

                }
            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
            }

            return RedirectToAction("Add", new { customEmployee.IdNumber });

        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(CustomEmployee customEmployee)
        {
            try
            {
                bool isChangingJob = false;

                //Get the last job possition assigned to the employee
                int oldJob = _context.JobHistories.Where(x => x.EmployeeIdNumber.Equals(customEmployee.IdNumber)).OrderByDescending(x => x.Id).FirstOrDefault()!.JobId;
                //Gets the new possition to be assigned
                int newJob = customEmployee.CurrentJob;

                if (oldJob != newJob)
                    isChangingJob = true;

                _context.Employees.Update(customEmployee.GetEmployee());

                //Creates an employee out when the status requires it
                if (ValidateOut(customEmployee))
                {
                    SetJobEndDate(customEmployee, oldJob);

                    await _context.EmployeeInOuts.AddAsync(customEmployee.GetEmployeeOut());
                }

                //Creates an employee in when the status requires it
                else if (ValidateIn(customEmployee))
                {
                    if (!isChangingJob)
                        await _context.JobHistories.AddAsync(customEmployee.GetJobHistory());

                    await _context.EmployeeInOuts.AddAsync(customEmployee.GetEmployeeIn());
                }

                //Create a new registry on the Job History when a new job possition is assigned
                if (isChangingJob)
                {
                    SetJobEndDate(customEmployee, oldJob);

                    await _context.JobHistories.AddAsync(customEmployee.GetJobHistory());
                }

                await _context.SaveChangesAsync();

                if (isOk)
                {
                    _notyf.Success("Empleado actualizado con éxito");
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                _notyf.Error(ex.Message);
            }

            return RedirectToAction("Edit", new { customEmployee.IdNumber });

        }

        #endregion

        //Validates if the employee requires to create an out
        private bool ValidateOut(CustomEmployee customEmployee)
        {
            try
            {
                if (customEmployee.CurrentStatus == (int)Globals.Status.OutOfCompany)
                    if (!string.IsNullOrEmpty(customEmployee.OutReason))
                    {
                        return true;
                    }
                    else
                    {
                        isOk = false;
                        _notyf.Error("Se requiere indicar el motivo");
                    }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Validates if the employee requires to create an in
        private bool ValidateIn(CustomEmployee customEmployee)
        {
            try
            {
                if (customEmployee.CurrentStatus == (int)Globals.Status.InCompany)
                    //Look out for the last In/Out of the employee, returns true if the the last movement is an out, so it requires an in
                    if (_context.EmployeeInOuts.OrderByDescending(x => x.Id).Where(x => x.EmployeeIdNumber.Equals(customEmployee.IdNumber)).FirstOrDefault()!.Type.Equals(InOutTypes.EmployeeOut))
                    {
                        return true;
                    }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Sets the end date to the last job of the employee
        private void SetJobEndDate(CustomEmployee customEmployee, int oldJob)
        {
            try
            {
                JobHistory jobHistory = _context.JobHistories.Where(x => x.EmployeeIdNumber.Equals(customEmployee.IdNumber) && x.JobId == oldJob).OrderByDescending(x => x.Id).FirstOrDefault()!;
                jobHistory.EndDate = DateTime.Now;
                _context.JobHistories.Update(jobHistory);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}