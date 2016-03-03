using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kingsley.io.Models
{
    public class KingsleyAccount
    {
        public int KingsleyAccountID { get; set; }

        [Required]
        [StringLength(500)]
        [Column(TypeName = "nvarchar")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar")]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date Joined")]
        public DateTime? JoinDate { get; set; }

        public string Name
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ApplicationUserID { get; set; }
    }
}