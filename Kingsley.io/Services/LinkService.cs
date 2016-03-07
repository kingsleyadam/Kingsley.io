using Kingsley.io.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kingsley.io.Services
{
    public class LinkService
    {
        private ApplicationDbContext db;

        public LinkService(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public LinkType CreateLinkType(string name)
        {
            var db = new ApplicationDbContext();
            var linkType = new LinkType { Name = name };

            db.LinkTypes.Add(linkType);
            db.SaveChanges();

            return linkType;
        }
    }
}