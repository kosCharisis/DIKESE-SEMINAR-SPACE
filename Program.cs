using DIKESE.Data;
using DIKESE.Data.Cart;
using DIKESE.Data.Services;
using DIKESE.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DIKESE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Dbcontext configuration
            var connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DikeseDbContext>(options => options.UseSqlServer(connString));

            //Services configuration
            builder.Services.AddScoped<ISpeakersService, SpeakersService>();
            builder.Services.AddScoped<ISponsorsService, SponsorsService>();
            builder.Services.AddScoped<IRoomsService, RoomsService>();
            builder.Services.AddScoped<ISeminarsService, SeminarsService>();
            builder.Services.AddScoped<IOrdersService, OrdersService>();

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

            // Authentication and authorization
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<DikeseDbContext>();
            builder.Services.AddMemoryCache();

            builder.Services.AddSession();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            });


            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
            app.UseSession();

            //Authentication and Authorization
            app.UseAuthentication();
            app.UseAuthorization();

            //Seed Database
            DikeseDbInitializer.Seed(app);
            DikeseDbInitializer.SeedUsersAndRolesAsync(app).Wait();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
