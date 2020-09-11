using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MenuMaker.Data
{
    public class DbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var adminRole = new IdentityRole { Name = "admin" };
            var userRole = new IdentityRole { Name = "user" };
            var superUserRole = new IdentityRole { Name = "superUser" };

            roleManager.Create(adminRole);
            roleManager.Create(userRole);
            roleManager.Create(superUserRole);

            var admin = new ApplicationUser
            {
                Email = "admin@admin.admin",
                UserName = "admin@admin.admin",
            };
            string adminPassword = "admin@admin.admin";
            var adminSaveResult = userManager.Create(admin, adminPassword);
            if (adminSaveResult.Succeeded)
            {
                userManager.AddToRole(admin.Id, adminRole.Name);
                userManager.AddToRole(admin.Id, adminRole.Name);
                userManager.AddToRole(admin.Id, adminRole.Name);
            }

            var user = new ApplicationUser
            {
                Email = "user@user.user",
                UserName = "user@user.user",
            };
            string userPassword = "user@user.user";
            var userSaveResult = userManager.Create(user, userPassword);
            if (userSaveResult.Succeeded)
            {
                userManager.AddToRole(user.Id, userRole.Name);
                userManager.AddToRole(user.Id, userRole.Name);
                userManager.AddToRole(user.Id, userRole.Name);
            }

            var superUser = new ApplicationUser
            {
                Email = "superUser@superUser.superUser",
                UserName = "superUser@superUser.superUser",
            };
            string superUserPassword = "superUser@superUser.superUser";
            var superUserSaveResult = userManager.Create(superUser, superUserPassword);
            if (superUserSaveResult.Succeeded)
            {
                userManager.AddToRole(superUser.Id, superUserRole.Name);
                userManager.AddToRole(superUser.Id, superUserRole.Name);
                userManager.AddToRole(superUser.Id, superUserRole.Name);
            }

            context.SaveChanges();
        }
    }
}
