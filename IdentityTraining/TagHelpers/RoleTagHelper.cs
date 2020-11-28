using IdentityTraining.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityTraining.TagHelpers
{
    [HtmlTargetElement("RolGoster")] //Çalışacağı tag helper ismini tanımlıyoruz
    public class RoleTagHelper:TagHelper //Tag Helper özellikleri için kalıtım aldık
    {
        public int UserId { get; set; }

        private readonly UserManager<AppUser> _userManager;

        public RoleTagHelper(UserManager<AppUser> userManager) //Dependency ile user manager oluşturdum
        {
            _userManager = userManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) //Asenkron metot çalışacağı için bu yapıya uygun metodu override ettik
        {
            var user = _userManager.Users.FirstOrDefault(i=>i.Id==UserId); //User i aldık
            var roles = await _userManager.GetRolesAsync(user); //Rollerini aldık

            var buildir = new StringBuilder();
            foreach (var role in roles)
            {
                buildir.Append($"<strong>{role}, </strong>");
            }
            output.Content.SetHtmlContent(buildir.ToString()); //Çıktıyı oluşturup output'a veriyoruz
        }
    }
}
