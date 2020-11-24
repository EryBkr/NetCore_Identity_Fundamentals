using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTraining.Context
{
    public class AppUser:IdentityUser<int> //PrimaryKey tipini generic olarak verdik
    {
        public string PictureURL { get; set; }
        public string Cinsiyet { get; set; }
    }
}
