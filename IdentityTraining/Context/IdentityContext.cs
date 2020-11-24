using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTraining.Context
{
    //IdentityDbContext en kök haliyle DbContext'ten kalıtım almıştır.
    public class IdentityContext:IdentityDbContext<AppUser,AppRole,int> //Extend ettiğimiz rol ve user tablolarımızı generic olarak veriyoruz
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database=IdentityDB;Server=(localdb)\MSSQLLocalDB;Trusted_Connection=True;"); //Connection String eklendi
        }
    }
}
