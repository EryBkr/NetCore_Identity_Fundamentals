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
        private readonly UserManager<AppUser> _userManager;//User işlemleri için oluşturduk

        public RoleController(RoleManager<AppRole> roleManager,UserManager<AppUser> userManager) //Dependency 
        {
            _roleManager = roleManager;
            _userManager = userManager;
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

        public IActionResult UserList()
        {
            var users = _userManager.Users.ToList(); //Kullanıcıları aldık
            return View(users);
        }

        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(i => i.Id == id); //Kullanıcıy aldık
            var roles = _roleManager.Roles.ToList();//Tüm rolleri getirdik
            var userRoles = await _userManager.GetRolesAsync(user); //Kullanıcının rollerini aldık

            List<RoleAssignViewModel> models = new List<RoleAssignViewModel>();

            TempData["UserId"] = user.Id; //User ID ataması yaptık

            foreach (var item in roles)
            {
                var model = new RoleAssignViewModel();
                model.RoleId = item.Id;
                model.Name = item.Name;
                model.Exist = userRoles.Contains(item.Name); //Kullanıcı bu rolü içeriyor mu? Duruma göre boolean değere atama yapıyoruz
                models.Add(model);
            }
            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> models)
        {
            var userId = (int)TempData["UserId"]; //User id yi aldık
            var user = _userManager.Users.FirstOrDefault(i => i.Id == userId); //Kullanıcıy aldık

            foreach (var item in models)
            {
                if (item.Exist)
                {
                    await _userManager.AddToRoleAsync(user,item.Name); //Kullanıcıya rol ataması yaptık
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user,item.Name); //Seçilmeyen rolleri kullanıcıdan çıkarttık
                }
            }  
            return RedirectToAction("UserList");
        }

    }
}