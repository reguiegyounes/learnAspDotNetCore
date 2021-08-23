﻿using learnAspDotNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace learnAspDotNetCore.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View(model);
        }
    }
}
