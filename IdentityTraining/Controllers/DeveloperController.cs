using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTraining.Controllers
{
    [Authorize(Roles = "Admin,Developer")] //Buraya sadece Admin veya Developer rolüne sahip kişiler girebilir
    public class DeveloperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}