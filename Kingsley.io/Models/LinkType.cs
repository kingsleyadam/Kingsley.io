using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kingsley.io.Models
{
    public class LinkType
    {
        public int LinkTypeID { get; set; }

        [Required]
        [StringLength(200)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Link Type")]
        public string Name { get; set; }
    }
}