using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kingsley.io.Models
{
    public class akLinksUser
    {
        public Guid UserID { get; set; }
        public int LinkID { get; set; }
        public aspnet_Users aspnet_User { get; set; }
        public akLinks akLink { get; set; }
    }
}