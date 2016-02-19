using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kingsley.io.Models
{
    public class akLinks
    {
        public int LinkID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Type { get; set; }
        public Guid AddedByUserID { get; set; }
        public ICollection<akLinksUser> UserLinks { get; set; }
    }
}