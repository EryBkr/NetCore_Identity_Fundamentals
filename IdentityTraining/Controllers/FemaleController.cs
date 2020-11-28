using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityTraining.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityTraining.Controllers
{
    public class FemaleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public FemaleController(UserManager<AppUser> _userManager)
        {
            this._userManager = _userManager;
        }

        [Authorize(Policy = "FemalePolicy")] //Startupta tanımladığımız policy ismi verildi
        public IActionResult Index()
        {
            return View();
        }

        public async  Task<IActionResult> AddClaim(int id)
        {
            var user=_userManager.Users.FirstOrDefault(i=>i.Id==id);//Kullanıcıyı aldık

            if ((await _userManager.GetClaimsAsync(user)).Count==0) //Kullanıcı Claime sahip değilse claim ekleme işlemi yapıyoruz
            {
                Claim claim = new Claim("gender", "female"); //Claim oluşturduk
                await _userManager.AddClaimAsync(user, claim); //Kullanıcıya claim ekledik
            }
          
            return RedirectToAction("UserList","Role");
        }
    }
}