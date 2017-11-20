using System;
using Microsoft.Owin;
using Owin;
using Medi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(Medi.Startup))]
namespace Medi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext _context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            // Create Admin role if it doesn't exist
            if (!roleManager.RoleExists("Admin"))
            {
                // Admin role creation
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);



                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "tom.jawo@gmail.com";
                user.FirstName = "Tomasz";
                user.LastName = "Jaworski";
                
                string pass = "admin1234";
              

                var chkUser = UserManager.Create(user,pass);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id,"Admin");
                }
                else
                {
                    throw new Exception();
                }
            }

            // creating Creating Manager role   
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists("Patient"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Patient";
                roleManager.Create(role);

            }
        }
    }
}
