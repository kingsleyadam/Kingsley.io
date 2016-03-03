namespace Kingsley.io.Migrations
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Services;

    internal sealed class Configuration : DbMigrationsConfiguration<Kingsley.io.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Kingsley.io.Models.ApplicationDbContext";
        }

        protected override void Seed(Kingsley.io.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            //Create Admin Role Group
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
            context.SaveChanges();

            //Create Admin User If Not Already Created, otherwise go find it.
            if (!context.Users.Any(t=>t.UserName == "adam@kingsley.io"))
            {
                var user = new ApplicationUser { UserName = "adam@kingsley.io", Email = "adam@kingsley.io" };
                userManager.Create(user, "passW0rd!");

                var service = new KingsleyAccountService(context);
                service.CreateKingsleyAccount("Admin", "User", user.Id);

                userManager.AddToRole(user.Id, "Admin");
            } else
            {
                var user = userManager.FindByName("adam@kingsley.io");

                if (!userManager.IsInRole(user.Id, "Admin"))
                    userManager.AddToRole(user.Id, "Admin");                
            }
        }
    }
}
