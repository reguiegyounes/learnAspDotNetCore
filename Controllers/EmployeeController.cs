using learnAspDotNetCore.Models;
using learnAspDotNetCore.Models.Repositories;
using learnAspDotNetCore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace learnAspDotNetCore.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly ICompanyRepository<Employee> _employee;
        private readonly IHostingEnvironment hostingEnvironment;

        public EmployeeController(ICompanyRepository<Employee> employee, IHostingEnvironment hostingEnvironment)
        {
            this._employee = employee;
            this.hostingEnvironment = hostingEnvironment;
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                if (model.Image!=null)
                {
                    string path = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                    fileName = Guid.NewGuid() + "_" + model.Image.FileName;
                    path = Path.Combine(path,fileName);
                    model.Image.CopyTo(new FileStream(path, FileMode.Create));
                }
                Employee emp = new Employee() {
                    Email = model.Email,
                    Name = model.Name,
                    Departement = model.Departement,
                    ImageUrl = fileName
                };
                _employee.Add(emp);
                return RedirectToAction("Details", new { id = emp.Id });
            }
            return View();
        }
    }
}
