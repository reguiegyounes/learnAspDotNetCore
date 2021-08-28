using learnAspDotNetCore.Models;
using learnAspDotNetCore.Models.Types;
using learnAspDotNetCore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learnAspDotNetCore.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public readonly UserManager<AppUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,
                                        UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(AdministrationCreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole()
                {
                    Name = model.RoleName
                };
                IdentityResult result=await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(actionName: "Roles");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Roles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id != null)
            {
                var role = await roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    EditRoleViewModel model = new EditRoleViewModel()
                    {
                        Id=role.Id,
                        RoleName = role.Name,
                        Users=new List<string>()
                    };
                    foreach (AppUser user in userManager.Users)
                    {
                        if (await userManager.IsInRoleAsync(user, role.Name))
                        {
                            model.Users.Add(user.Email);
                        };
                    }
                    return View(model);
                }
                StatusResult result=new StatusResult() { 
                    Message=$"The Role as ID {id} cannot be found" 
                };
                return View("../Error/NotFound",result);
            }
            return RedirectToAction("Roles");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.Id);
                if (role == null)
                {
                    StatusResult status = new StatusResult()
                    {
                        Message = $"The Role as ID {model.Id} cannot be found"
                    };
                    return View("../Error/NotFound", status);
                }
                
                role.Name = model.RoleName;
                IdentityResult result =await this.roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                
            }
            return View(model);
        }
        public async Task<IActionResult> CheckingRoleName(EditRoleViewModel model)
        {
            var role = await roleManager.FindByNameAsync(model.RoleName);
            if (role == null) return Json(true);
            else return Json($"This role name ( {model.RoleName} ) is already exist.");
        }
    }
}
