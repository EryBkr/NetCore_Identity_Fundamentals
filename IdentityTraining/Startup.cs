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
            services.AddControllersWithViews(); //MVC yap�s� Eklendi
            services.AddDbContext<IdentityContext>();//Database eklendi
            
            //Identity k�t�phanesini aya�a kald�rd�k
            services.AddIdentity<AppUser, AppRole>(opt=> { //Bu k�s�mda konfig�rasyon ayarlar�m�z� yap�yoruz

                opt.Password.RequireDigit = false; //Say� olma zorunlulu�unu kald�rd�k
                opt.Password.RequireLowercase = false; //K���k harf zorunlulu�unu kald�rd�k
                opt.Password.RequiredLength = 1;//Karakter say�s�n� d���rd�k
                opt.Password.RequireNonAlphanumeric = false;//�zel karakter zorunlulu�u kald�r�ld�
                opt.Password.RequireUppercase = false;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);//Belli bir say�da yanl�� girilme durumunda 10 dakikal���na ki�iyi kitliyoruz
                opt.Lockout.MaxFailedAccessAttempts = 3;//3 kere yanl�� giri� yap�l�rsa lockOut durumuna d��er

            }).AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<IdentityContext>();//Custom Identity hatalar�m�z� g�r�nt�lemek i�in konfig�rasyona ekledik

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.HttpOnly = true;//JS Cookie bilgilerine ula�amaz
                opt.Cookie.Name = "MyCookie";
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;//Http ya Https �zerinden �al���r
                opt.ExpireTimeSpan = TimeSpan.FromDays(20); //Cookie ka� g�n ayakta kals�n
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
            app.UseStaticFiles();//wwwroot klas�r�n� d��ar�ya a�t�k

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();//Default url �emas�n� kulland�k
            });
        }
    }
}
