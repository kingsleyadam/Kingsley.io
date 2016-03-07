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
            //Admin User Information
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

            //Link Type Information
            LinkService linkService = new LinkService(context);
            LinkType otherLinkType;
            if (!context.LinkTypes.Any(l => l.Name == "Kenexa Links"))
                linkService.CreateLinkType("Kenexa Links");

            if (!context.LinkTypes.Any(l => l.Name == "Other Links"))
                otherLinkType = linkService.CreateLinkType("Other Links");
            else
                otherLinkType = context.LinkTypes.Where(l => l.Name == "Other Links").First();

            if (!context.LinkTypes.Any(l => l.Name == "Folder Links"))
                linkService.CreateLinkType("Folder Links");
            if (!context.LinkTypes.Any(l => l.Name == "IBM Links"))
                linkService.CreateLinkType("IBM Links");
            if (!context.LinkTypes.Any(l => l.Name == "Development Links"))
                linkService.CreateLinkType("Development Links");

            //Link Information
            if (!context.Links.Any(l => l.Address.Contains("google.com")))
            {
                context.Links.AddOrUpdate(new Link { Name = "Google", Address = "http://google.com", LinkTypeID = otherLinkType.LinkTypeID });
                context.SaveChanges();
            }
              
        }
    }
}
