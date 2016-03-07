using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kingsley.io.Models
{
    public class Link
    {
        [Display(Name="Link ID")]
        public int LinkID { get; set; }

        [Required]
        [Display(Name = "Link Name")]
        public string Name { get; set; }
        
        [Required]
        [RegularExpression("(http|ftp|https):\\/\\/[\\w\\-_]+(\\.[\\w\\-_]+)+([\\w\\-\\.,@?^=%&amp;:/~\\+#]*[\\w\\-\\@?^=%&amp;/~\\+#])?", ErrorMessage = "Invalid link format (e.g. http://...)")]
        [Display(Name = "Full Address")]
        public string Address { get; set; }

        public virtual LinkType type { get; set; }

        [Required]
        public int LinkTypeID { get; set; }
    }
}