using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kingsley.io.Models;

namespace Kingsley.io.Services
{
    public class KingsleyAccountService
    {
        private ApplicationDbContext db;

        public KingsleyAccountService (ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        public void CreateKingsleyAccount(string firstName, string lastName, string userID)
        {
            var db = new ApplicationDbContext();
            var kingsleyAccount = new KingsleyAccount { FirstName = firstName, LastName = lastName, JoinDate = DateTime.Now, ApplicationUserID = userID };

            db.KingsleyAccounts.Add(kingsleyAccount);
            db.SaveChanges();
        }
    }
}