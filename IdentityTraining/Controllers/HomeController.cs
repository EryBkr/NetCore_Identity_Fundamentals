using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityTraining.Context;
using IdentityTraining.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTraining.Controllers
{
    public class HomeController : Controller
    {
        //Identity kütüphanesine ait , veritabanına erişmek için kullandığımız bir classtır
        private readonly UserManager<AppUser> _userManager;

        //Identity kutuphanesine ait login işlemlerini yöneteceğimiz class
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> _signInManager) //Dependency Injection yapıyorum
        {
            this._userManager = userManager;
            this._signInManager = _signInManager;
        }

        public IActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> LogIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
               var result=await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false); //Son iki parametre kullanıyı hatırlayayım mı ve sürekli yanlış girerse bloklayayım mı?

                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Panel");
                }
                ModelState.AddModelError("","Kullanıcı adı veya şifre hatalı");
            }
            return RedirectToAction("Index",model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model) //Kayıt metodumuz asenkron olduğu için Action Metoduuz da asenkron oldu
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser //Kullanıcı identity nesnesini modelimiz aracılığıyla oluşturduk
                {
                    Email = model.EMail,
                    UserName = model.UserName
                };

                var result=await _userManager.CreateAsync(appUser,model.Password); //Kullanıcı kayıt işlemi
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}