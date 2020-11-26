using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IdentityTraining.Context;
using IdentityTraining.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            var user = await _userManager.FindByNameAsync(name); //Kullanıcı isminden kullanıcıyı bulduk
            return View(user);
        }

        public async Task<IActionResult> UserUpdate()
        {
            var name = User.Identity.Name;//Cookie de bulunan ismi aldık
            var user = await _userManager.FindByNameAsync(name); //Kullanıcı isminden kullanıcıyı bulduk

            var model = new UserUpdateViewModel //Modelimizi map liyoruz
            {
                Email = user.Email,
                UserName = user.UserName,
                Phone = user.PhoneNumber,
                PictureUrl = user.PictureURL
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserUpdate(UserUpdateViewModel userUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                var name = User.Identity.Name;//Cookie de bulunan ismi aldık
                var user = await _userManager.FindByNameAsync(name); //Kullanıcı isminden kullanıcıyı bulduk

                if (userUpdateViewModel.Picture!=null) //Kişi dosya girmiş ise güncelleme yapacağız.Diğer türlü bu işlem boş yere yapılmış olur
                {
                    var appFile = Directory.GetCurrentDirectory();//Uygulamanın çalıştığı yer
                    var fileExtension = Path.GetExtension(userUpdateViewModel.Picture.FileName);//Dosyanın uzantısını aldık
                    var pictureName = Guid.NewGuid() + fileExtension;//Randoom resim adı ve uzantısı
                    var kaydedilecekYer = appFile + "/wwwroot/img/" + pictureName; //Resmin kaydedileceği yer
                    using var stream = new FileStream(kaydedilecekYer, FileMode.Create);//Resim nereye kaydedilecek ve yetkisini belirledik,using tanımladık işlemi bitince yer kaplamasın

                    await userUpdateViewModel.Picture.CopyToAsync(stream); //Dosyayı fiziksel olarak asenkron olarak kaydediyoruz
                    user.PictureURL = pictureName; //Resim adını verdik
                }

                //Kullanıcı güncelleme işlemleri
                user.UserName = userUpdateViewModel.UserName;
                user.Email = userUpdateViewModel.Email;
                user.PhoneNumber = userUpdateViewModel.Phone;
                user.PictureURL = userUpdateViewModel.PictureUrl;

                var result=await _userManager.UpdateAsync(user);//Güncelleme işleminin çalıştığı yer

                if (result.Succeeded)//güncelleme başarılı ise
                {
                    return RedirectToAction("Index");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);//Hata var ise ekliyoruz
                }
            }
            return View(userUpdateViewModel);
        }

        [AllowAnonymous] //bu metoda giriş için cookie değerine ihtiyacımız yok artık.
        public IActionResult AllAccessUser()
        {
            return View();
        }
    }
}