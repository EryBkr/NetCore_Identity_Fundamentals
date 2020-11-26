using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTraining.Models
{
    public class UserUpdateViewModel //Güncelleme modelimiz
    {
        [Required(ErrorMessage ="Email alanı gereklidir")]
        [EmailAddress(ErrorMessage ="Geçerli bir mail adresi giriniz")] //Email adres formatında girilmesini sağlıyoruz
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "UserName alanı gereklidir")]
        public string UserName { get; set; }

        public string PictureUrl { get; set; }

        public IFormFile Picture { get; set; }
    }
}
