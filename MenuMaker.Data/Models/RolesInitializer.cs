using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace MenuMaker.Data.Models
{
    public static class RolesInitializer
    {
        public static void Initialize()
        {
            using (var ctx = new IdentityDbContext<ApplicationUser>())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));
                var rolesList = roleManager.Roles.ToList();

                if (rolesList.Count == 0)
                {
                    //Roles to add to a DB.
                    var userRole = new IdentityRole { Name = "user" };
                    var superUserRole = new IdentityRole { Name = "superUser" };
                    var adminRole = new IdentityRole { Name = "admin" };

                    //Adding Roles to DB.
                    roleManager.Create(userRole);
                    roleManager.Create(superUserRole);
                    roleManager.Create(adminRole);

                    ctx.SaveChanges();
                }
            }
        }
    }
}
