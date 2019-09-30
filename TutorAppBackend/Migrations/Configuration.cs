namespace TutorAppBackend.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TutorAppBackend.Models;
    using static TutorAppBackend.ApplicationUserManager;

    internal sealed class Configuration : DbMigrationsConfiguration<TutorAppBackend.Models.TutorAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TutorAppBackend.Models.TutorAppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                roleManager.Create(new IdentityRole("Admin"));
                roleManager.Create(new IdentityRole("Tutor"));
                roleManager.Create(new IdentityRole("Alumno"));
            }

            if (!context.Users.Any())
            {
                var userStore = new ApplicationUserStore(context);
                var userManager = new ApplicationUserManager(userStore);
                var admin = new ApplicationUser() { UserName = "admin@tutorapp.com", Email = "admin@tutorapp.com", Name = "Hans", LastName = "Soto", Dni = "99988877", PhoneNumber = "87127666" };
                var tutor = new ApplicationUser() { UserName = "tutor@tutorapp.com", Email = "tutor@tutorapp.com", Name = "Angel", LastName = "Velasquez", Dni = "99988855", PhoneNumber = "87127413" };
                var student = new ApplicationUser() { UserName = "alumno@tutorapp.com", Email = "alumno@tutorapp.com", Name = "Jason", LastName = "Almandroz", Dni = "99988866", PhoneNumber = "87127514" };
                var result1 = userManager.Create(admin, "Admin.123");
                var result2 = userManager.Create(tutor, "Tutor.123");
                var result3 = userManager.Create(student, "Alumno.123");
            }

            if (context.Users.Any(x => !x.Roles.Any()))
            {
                var userStore = new ApplicationUserStore(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var admin = userManager.FindByEmail("admin@tutorapp.com");
                if (!userManager.GetRoles(admin.Id).Any())
                    userManager.AddToRole(admin.Id, "Admin");
                var tutor = userManager.FindByEmail("tutor@tutorapp.com");
                if (!userManager.GetRoles(tutor.Id).Any())
                    userManager.AddToRole(tutor.Id, "Tutor");
                var student = userManager.FindByEmail("alumno@tutorapp.com");
                if (!userManager.GetRoles(student.Id).Any())
                    userManager.AddToRole(student.Id, "Alumno");
            }
        }
    }
}
