using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;

namespace SignalRWebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Giri� yapan kullan�c�y� zorunlu k�l
            var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

            // Add services to the container.
            builder.Services.AddDbContext<SignalRContext>();
            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<SignalRContext>();
            builder.Services.AddHttpClient();
            builder.Services.AddControllersWithViews(opt =>
            {
                //�rnek olarak kategori sayfas�na g�r�nt�lemek i�in account login yapmam gerek
                //B�t�n Controllerlara bu filtreyi uygula
                opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
            });
            builder.Services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = "/Login/Index/";
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
