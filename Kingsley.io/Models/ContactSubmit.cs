using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kingsley.io.Models
{
    public class ContactSubmit
    {
        public int ContactSubmitID { get; set; }

        [Required]
        [StringLength(500)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(500)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(1000)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Email")]
        [RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Message field is required.")]
        [StringLength(1000)]
        [Display(Name = "Send us a message")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        [Required]
        public DateTime SubmitDate { get; set; }

        public string Name
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }
    }
}