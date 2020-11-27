using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityTraining.Context;
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
    }
}