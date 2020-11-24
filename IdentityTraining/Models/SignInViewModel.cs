using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTraining.Models
{
    public class SignInViewModel //Giriş işlemleri için Model oluşturduk
    {
        [Display(Name ="Kullanıcı Adı:")] //Display kısımları label görünümlerini belirtir
        [Required(ErrorMessage ="Kullanıcı adı boş olamaz")]
        public string UserName { get; set; }

        [Display(Name = "Şifre:")]
        [Required(ErrorMessage = "Şifre boş olamaz")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
