using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Entities
{
    public class User : EntityBaseClass
    {
        [Key]
        public Guid UserId { get; set; }

        public Guid AspUserId { get; set; }

        [Required(ErrorMessage = "First Name required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a maximum length of '50'.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "The field {0} must be a maximum length of '50'.")]
        [DisplayName("Middile Name")]
        public string MiddileName { get; set; }

        [Required(ErrorMessage = "Last Name required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a maximum length of '50'.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a maximum length of '100'.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        [StringLength(20, ErrorMessage = "The field {0} must be a maximum length of '20'.")]
        public string PhoneNumber { get; set; }

        [DisplayName("Mobile Number")]
        [StringLength(20, ErrorMessage = "The field {0} must be a maximum length of '20'.")]
        public string MobileNumber { get; set; }

        public string ImagePath { get; set; }

        public DateTime LastLogin { get; set; }

        public User()
        {
            LastLogin = DateTime.Now;
        }
    }
}
