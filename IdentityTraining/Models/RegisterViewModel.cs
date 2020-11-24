using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTraining.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş olamaz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Parola adı boş olamaz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Parola Tekrarı adı boş olamaz")]
        [Compare("Password",ErrorMessage ="Parolalar eşleşmiyor")] //Parola eşleşme kontrolü
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email boş olamaz")]
        public string EMail { get; set; }
    }
}
