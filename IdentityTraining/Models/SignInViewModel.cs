using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTraining.Models
{
    public class SignInViewModel //Giriş işlemleri için Model oluşturduk
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
