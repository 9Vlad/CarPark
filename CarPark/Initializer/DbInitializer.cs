using CarPark;
using CarPark.Data;
using CarPark.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Rocky_DataAccess.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly CarParkContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(CarParkContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch(Exception ex)
            {

            }


            if (!_roleManager.RoleExistsAsync(WebConstants.ManagerRole).GetAwaiter().GetResult())
            {
                 _roleManager.CreateAsync(new IdentityRole(WebConstants.ManagerRole)).GetAwaiter().GetResult();
                 _roleManager.CreateAsync(new IdentityRole(WebConstants.SupervisorRole)).GetAwaiter().GetResult();
                 _roleManager.CreateAsync(new IdentityRole(WebConstants.ClientRole)).GetAwaiter().GetResult();
            }
            else
            {
                return;
            }

            _userManager.CreateAsync(new TClient
            {
                UserName = "client@gmail.com",
                Email = "client@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111"
            }, "Client123*").GetAwaiter().GetResult();

            _userManager.CreateAsync(new IdentityUser
            {
                UserName = "supervisor@gmail.com",
                Email = "supervisor@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111"
            }, "Supervisor123*").GetAwaiter().GetResult();

            _userManager.CreateAsync(new IdentityUser
            {
                UserName = "manager@gmail.com",
                Email = "manager@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111"
            }, "Manager123*").GetAwaiter().GetResult();

            IdentityUser client = _userManager.FindByEmailAsync("client@gmail.com").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(client, WebConstants.ClientRole).GetAwaiter().GetResult();

            IdentityUser manager = _userManager.FindByEmailAsync("manager@gmail.com").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(manager, WebConstants.ManagerRole).GetAwaiter().GetResult();

            IdentityUser supervisor = _userManager.FindByEmailAsync("supervisor@gmail.com").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(supervisor, WebConstants.SupervisorRole).GetAwaiter().GetResult();
        }
    }
}
