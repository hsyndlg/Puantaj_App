using Microsoft.AspNetCore.Identity;
using Puantaj.Business.Extensions;
using Puantaj.Entity.AutoMapper.Profiles;

namespace Puantaj.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.LoadMyServices();
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(UserProfile), typeof(PersonelProfile), typeof(ProjeProfile), typeof(PuantajCizelgeProfile));
            builder.Services.AddSession();

            // Cookie Options
            builder.Services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = new PathString("/Home/Login");
                option.LogoutPath = new PathString("/Home/Logout");
                option.Cookie = new CookieBuilder()
                {
                    Name = "PuantajApp",
                    HttpOnly = true, // Cookie gizle
                    SameSite = SameSiteMode.Strict,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
                option.SlidingExpiration = true;
                option.ExpireTimeSpan = System.TimeSpan.FromDays(7);
                option.AccessDeniedPath = new PathString("/Admin/AccessDenied");
            });

            // Identity Options
            builder.Services.Configure<IdentityOptions>(options => 
            {
                options.SignIn.RequireConfirmedEmail = true;
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "AddUser",
                    pattern: "{controller=Home}/{action=Login}/{id?}"
                );
            });

            app.Run();
        }
    }
}