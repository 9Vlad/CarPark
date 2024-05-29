using CarPark.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rocky_DataAccess.Initializer;

namespace CarPark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<CarParkContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultTokenProviders().AddDefaultUI()
                .AddEntityFrameworkStores<CarParkContext>();

            // Seeding Database
            builder.Services.AddScoped<IDbInitializer, DbInitializer>();

            var app = builder.Build();

            using (var serviceScope = app.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var dbInitializer = services.GetRequiredService<IDbInitializer>();
                dbInitializer.Initialize();
            }

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
            app.MapRazorPages();

            app.Run();
        }
    }
}
