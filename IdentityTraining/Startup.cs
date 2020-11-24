using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityTraining.Context;
using IdentityTraining.CustomValidator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityTraining
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); //MVC yapýsý Eklendi
            services.AddDbContext<IdentityContext>();//Database eklendi
            
            //Identity kütüphanesini ayaða kaldýrdýk
            services.AddIdentity<AppUser, AppRole>(opt=> { //Bu kýsýmda konfigürasyon ayarlarýmýzý yapýyoruz

                opt.Password.RequireDigit = false; //Sayý olma zorunluluðunu kaldýrdýk
                opt.Password.RequireLowercase = false; //Küçük harf zorunluluðunu kaldýrdýk
                opt.Password.RequiredLength = 1;//Karakter sayýsýný düþürdük
                opt.Password.RequireNonAlphanumeric = false;//özel karakter zorunluluðu kaldýrýldý
                opt.Password.RequireUppercase = false;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);//Belli bir sayýda yanlýþ girilme durumunda 10 dakikalýðýna kiþiyi kitliyoruz
                opt.Lockout.MaxFailedAccessAttempts = 3;//3 kere yanlýþ giriþ yapýlýrsa lockOut durumuna düþer

            }).AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<IdentityContext>();//Custom Identity hatalarýmýzý görüntülemek için konfigürasyona ekledik

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.HttpOnly = true;//JS Cookie bilgilerine ulaþamaz
                opt.Cookie.Name = "MyCookie";
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;//Http ya Https üzerinden çalýþýr
                opt.ExpireTimeSpan = TimeSpan.FromDays(20); //Cookie kaç gün ayakta kalsýn
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();//wwwroot klasörünü dýþarýya açtýk

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();//Default url þemasýný kullandýk
            });
        }
    }
}
