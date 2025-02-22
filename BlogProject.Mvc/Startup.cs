using BlogProject.Mvc.AutoMapper.Profiles;
using BlogProject.Mvc.Helpers.Abstract;
using BlogProject.Mvc.Helpers.Concrete;
using BlogProject.Services.AutoMapper.Profiles;
using BlogProject.Services.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlogProject.Mvc
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; //nested(içiçe) objelerde çevrimi saðlar.
            }); //mvc uygulamasý olarak çalýþmasýný saðlar. Razor runtime ile view deðiþiklikleri tarayýcýya anýnda yansýr.
            services.AddSession();
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile), typeof(UserProfile)); //derlenme sýrasýnda Automapper bu projedeki sýnýflarý tarar.
            services.LoadMyServices();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Admin/User/Login");
                options.LogoutPath = new PathString("/Admin/User/Logout");
                options.Cookie = new CookieBuilder()
                {
                    Name = "BlogProject",
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict, //bu þekilde kullanýlmalýdýr.
                    SecurePolicy = CookieSecurePolicy.SameAsRequest //gerçek iþ sýrasýnda always seçilmelidir.
                };
                options.SlidingExpiration = true; //kullanýcý ayný cookie ayarlarý ile belirtilen süre içinde giriþ yapabilir.
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.AccessDeniedPath = new PathString("/Admin/User/AccessDenied"); //giriþ yapan fakat yetkisi olmayan kullanýcýlarý ilgili adrese yönlendirir.
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages(); //projede olmayan bir sayfa istenildiðinde 404 Not Found uyarýsýna yönlendirir.
            }

            app.UseSession();

            app.UseStaticFiles(); //tema dosyalarý(resim, css veya js)
            app.UseRouting();
            app.UseAuthentication(); //authentication ve authorization, routing ile endpoints arasýnda olmalýdýrlar.
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                    ); //MVC'de Admin area'sýna eriþim saðlanýr.
                endpoints.MapDefaultControllerRoute(); //ilk açýlýþta default olarak HomeController ve Index.cshtml'e yönlendirir.
            });
        }
    }
}
