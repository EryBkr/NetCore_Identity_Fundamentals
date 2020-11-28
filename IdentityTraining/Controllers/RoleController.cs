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
                var appRole = new AppRole() { Name = model.Name }; //App Role Entity si oluşturduk
                var result = await _roleManager.CreateAsync(appRole); //Rolü oluşturuluyoruz

                if (result.Succeeded) //Başarılıysa
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description); //Hataları modele ekleyip gönderdik
                }
            }
            return View(model);
        }

        public IActionResult UpdateRole(int id) //Güncelleme için Id aldık
        {
            var role = _roleManager.Roles.FirstOrDefault(i => i.Id == id); //Id ye ait rolü elde ettik
            RoleUpdateViewModel model = new RoleUpdateViewModel { Id = role.Id, Name = role.Name };//Modele aktardık

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model) //Güncellenecek değerleri aldık
        {
            var updatedModel = _roleManager.Roles.Where(i => i.Id == model.Id).FirstOrDefault(); //Rolü aldık
            updatedModel.Name = model.Name;
            var result=await _roleManager.UpdateAsync(updatedModel); //Rolü güncelledik

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("",item.Description);
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteRole(int id) //Silme işlemi için Id aldık
        {
            var deletedRole = _roleManager.Roles.FirstOrDefault(i => i.Id == id);//Rolü aldık
            var result=await _roleManager.DeleteAsync(deletedRole);//Rolü sildik

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            
            return View();
        }

    }
}