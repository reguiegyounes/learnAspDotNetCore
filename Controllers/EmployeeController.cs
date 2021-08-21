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
            if(emp == null){
                return View("NotFoundError",id);
            }
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
                    string extFile = Path.GetExtension(model.Image.FileName);
                    if (extFile != ".png" && extFile != ".jpg")
                    {
                        ModelState.AddModelError("", "Invalid file format");
                        return View(model);
                    }
                    fileName = CreateImage(model);
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee=_employee.Get(id);
            if (employee == null)
            {
                return View("NotFoundError", id);
            }
            if (employee!=null)
            {
                EmployeeEditViewModel model = new EmployeeEditViewModel()
                {
                    Id = employee.Id,
                    imageOldPath = employee.ImageUrl,
                    Name= employee.Name,
                    Email = employee.Email,
                    Departement = employee.Departement,
                };
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee emp = _employee.Get(model.Id);

                emp.Email = model.Email;
                emp.Name = model.Name;
                emp.Departement = model.Departement;
                
                if (model.Image != null)
                {
                    string extFile = Path.GetExtension(model.Image.FileName);
                    if (extFile != ".png" && extFile != ".jpg")
                    {
                        ModelState.AddModelError("", "Invalid file format");
                        return View(model);
                    }
                    emp.ImageUrl = CreateImage(model);

                    // delete old image
                    string pathOldImage = Path.Combine(webHostEnvironment.WebRootPath, "Images", model.imageOldPath);
                    if (System.IO.File.Exists(pathOldImage))
                    {
                        System.IO.File.Delete(pathOldImage);
                    }
                }
                
                _employee.Update(emp);
                return RedirectToAction("Details", new { id = emp.Id });
            }
            return View(model);
        }


        // 
        private string CreateImage(EmployeeCreateViewModel model)
        {
            string fileName;
            string path = Path.Combine(webHostEnvironment.WebRootPath, "Images");
            fileName = Guid.NewGuid() + "_" + model.Image.FileName;
            path = Path.Combine(path, fileName);
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                model.Image.CopyTo(fs);
            }

            return fileName;
        }
    }
}
