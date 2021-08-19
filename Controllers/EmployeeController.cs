using learnAspDotNetCore.Models;
using learnAspDotNetCore.Models.Repositories;
using learnAspDotNetCore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace learnAspDotNetCore.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly ICompanyRepository<Employee> _employee;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EmployeeController(ICompanyRepository<Employee> employee, IWebHostEnvironment webHostEnvironment)
        {
            this._employee = employee;
            this.webHostEnvironment = webHostEnvironment;
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
                if (model.Images!=null || model.Images.Count>0)
                {
                    
                    foreach (IFormFile file in model.Images)
                    {
                        string extFile = Path.GetExtension(file.FileName);
                        if (extFile!=".png" && extFile != ".jpg")
                        {
                            ModelState.AddModelError("", "Invalid file format");
                            return View(model);
                        }
                        string path = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                        fileName = Guid.NewGuid() + "_" + file.FileName;
                        path = Path.Combine(path, fileName);
                        file.CopyTo(new FileStream(path, FileMode.Create));
                    }
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
            return View(model);
        }
    }
}
