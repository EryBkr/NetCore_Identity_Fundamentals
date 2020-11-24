using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTraining.CustomValidator
{
    public class CustomIdentityValidator:IdentityErrorDescriber //Hata yönetim mesajları için kalıtım aldık
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError() {Code="PasswordTooShort",Description=$"Parola minimum {length} karakter olmalıdır" };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError() { Code = "PasswordRequiresNonAlphanumeric", Description = "Parola alfanumerik karakter içermelidir" };
        }
    }
}
