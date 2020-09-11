using MenuMaker.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
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
                userManager.AddToRole(admin.Id, userRole.Name);
                userManager.AddToRole(admin.Id, superUserRole.Name);
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
                userManager.AddToRole(superUser.Id, userRole.Name);
            }

            context.Days.AddRange(new List<Day>() {
            new Day(){ Id=1, Name = "Monday"},
            new Day(){ Id=2, Name = "Tuesday"},
            new Day(){ Id=3, Name = "Wednesday"},
            new Day(){ Id=4, Name = "Thursday"},
            new Day(){ Id=5, Name = "Friday"},
            new Day(){ Id=6, Name = "Saturday"},
            new Day(){ Id=7, Name = "Sunday"}
            });

            context.Ingridients.AddRange(new List<Ingredient>() { 
            new Ingredient(){  Name = "Potato"},
            new Ingredient(){  Name = "Fish"},
            new Ingredient(){  Name = "Beer"},
            new Ingredient(){  Name = "Wine"},
            new Ingredient(){  Name = "Sugar"},
            new Ingredient(){  Name = "Milk"},
            new Ingredient(){  Name = "Flour"},
            new Ingredient(){  Name = "Meat"},
            new Ingredient(){  Name = "Strawberry"},
            new Ingredient(){  Name = "Peach"},
            new Ingredient(){  Name = "XXX"},
            });



            context.SaveChanges();
        }
    }
}
