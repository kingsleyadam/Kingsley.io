using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kingsley.io.Models
{
    public class aspnet_Users
    {
        public Guid ApplicationID { get; set; }
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string LoweredUserName { get; set; }
        public string MobileAlias { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime LastActivityDate { get; set; }
        public ICollection<akLinksUser> UserLinks { get; set; }
    }
}