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
    [Authorize]//Giriş yapmamış kullanıcılar giremez
    public class PanelController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PanelController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var name = User.Identity.Name;//Cookie de bulunan ismi aldık
            var user=await _userManager.FindByNameAsync(name); //Kullanıcı isminden kullanıcıyı bulduk
            return View(user);
        }

        [AllowAnonymous] //bu metoda giriş için cookie değerine ihtiyacımız yok artık.
        public IActionResult AllAccessUser()
        {
            return View();
        }
    }
}