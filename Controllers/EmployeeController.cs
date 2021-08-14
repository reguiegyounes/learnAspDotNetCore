using learnAspDotNetCore.Models;
using learnAspDotNetCore.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace learnAspDotNetCore.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly ICompanyRepository<Employee> _employee;
        public EmployeeController(ICompanyRepository<Employee> employee)
        {
            _employee = employee;
        }

        public ViewResult Index()
        {
            IEnumerable<Employee> employees = _employee.GetAll();
            return View(employees);
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return RedirectToAction("Index");
            }
            Employee emp = _employee.Get(id ?? 1);
            return View(emp);
        }

    }
}
