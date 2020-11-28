using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTraining.Controllers
{
    [Authorize(Roles ="Admin")] //Buraya sadece Admin rolüne sahip kişiler girebilir
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}