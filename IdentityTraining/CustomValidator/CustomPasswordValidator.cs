using IdentityTraining.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTraining.CustomValidator
{
    public class CustomPasswordValidator : IPasswordValidator<AppUser> //Identity tarafında uygulanan Validasyonlara müdahale etmek için çağırdık
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            var errorList = new List<IdentityError>();
            if (password.ToLower().Contains(user.UserName))//Parola kullanıcı adını içermesin
            {
                errorList.Add(new IdentityError 
                {
                    Code="PasswordContainsUserName",
                    Description="Parola kullanıcı adını içeremez"
                });

            }

            if (errorList.Count>0) //Hataların hepsini ele alıp gönderiyoruz
            {
                return Task.FromResult(IdentityResult.Failed(errorList.ToArray()));
            }
            else
            {
                return Task.FromResult(IdentityResult.Success);
            }
        }
    }
}
