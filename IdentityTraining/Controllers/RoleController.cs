using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityTraining.Context;
using IdentityTraining.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTraining.Controllers
{
    [Authorize] //Giriş yapılmış olmalı 
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;//Tıpkı user manager gibi role manager da role ile ilgili işlemleri yapar

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();//Database de ki rollerin hepsini aldık
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View(new RoleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var appRole = new AppRole() {Name=model.Name }; //App Role Entity si oluşturduk
                var result = await _roleManager.CreateAsync(appRole); //Rolü oluşturuluyoruz

                if (result.Succeeded) //Başarılıysa
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description); //Hataları modele ekleyip gönderdik
                }
            }
            return View(model);
        }
    }
}