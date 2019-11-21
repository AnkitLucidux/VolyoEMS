using EMS.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.ViewModels
{
    public class UserViewModel : EntityBaseClass
    {
        [Key]
        public Guid UserId { get; set; }

        public Guid AspUserId { get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "Email required.")]
        [StringLength(100, ErrorMessage = "The field {0} must be a maximum length of '100'.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

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

        [DisplayName("Phone Number")]
        [StringLength(20, ErrorMessage = "The field {0} must be a maximum length of '20'.")]
        public string PhoneNumber { get; set; }

        [DisplayName("Mobile Number")]
        [StringLength(20, ErrorMessage = "The field {0} must be a maximum length of '20'.")]
        public string MobileNumber { get; set; }

        public DateTime LastLogin { get; set; }

        [Display(Name = "Role")]
        public string RoleId { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [NotMapped]
        public List<SelectListItem> Roles { get; set; }
    }
}
