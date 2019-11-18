using EMS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.ViewModels
{
    public class EmployeeViewModel:EntityBaseClass
    {
        [Key]
        public Guid EmployeeId { get; set; }

        public int EmployeeCode { get; set; }

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

        [DisplayName("Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Gender required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a maximum length of '50'.")]
        [DisplayName("Gender")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Gender required.")]
        [DisplayName("DOB")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Email Address required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a maximum length of '50'.")]
        [DisplayName("EmailAddress")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string EmailAddress { get; set; }

        [DisplayName("Father's Name")]
        [StringLength(50, ErrorMessage = "The field {0} must be a maximum length of '50'.")]
        public string FatherName { get; set; }

        [DisplayName("Mother's Name")]
        [StringLength(50, ErrorMessage = "The field {0} must be a maximum length of '50'.")]
        public string MotherName { get; set; }

        [DisplayName("Permanent Address")]
        public string PermanentAddress { get; set; }

        [DisplayName("Communication Address")]
        public string CommunicationAddress { get; set; }

        [StringLength(20, ErrorMessage = "The field {0} must be a maximum length of '20'.")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Mobile Number required.")]
        [StringLength(20, ErrorMessage = "The field {0} must be a maximum length of '20'.")]
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }

        [DisplayName("Aadhar Number")]
        [StringLength(20, ErrorMessage = "The field {0} must be a maximum length of '20'.")]
        public string AadharNumber { get; set; }

        [DisplayName("Pan Card Number")]
        [StringLength(20, ErrorMessage = "The field {0} must be a maximum length of '20'.")]
        public string PanNumber { get; set; }

        [DisplayName("Passport Number")]
        [StringLength(20, ErrorMessage = "The field {0} must be a maximum length of '20'.")]
        public string PassportNumber { get; set; }

        [DisplayName("Passport Expiry Date")]
        public DateTime PassportExpDate { get; set; }

        [DisplayName("Marital Status ")]
        public MaritalStatus MaritalStatus { get; set; }

        public int QualificationId { get; set; }

        public int DepartmentId { get; set; }

        public int DesignationId { get; set; }

        [DisplayName("Joining Date")]
        public DateTime JoiningDate { get; set; }

        [DisplayName("Total Experience")]
        public decimal TotalExperience { get; set; }

        [DisplayName("Past Experience")]
        public decimal PastExperience { get; set; }

        [DisplayName("Primary Skills")]
        public string PrimarySkills { get; set; }

        [DisplayName("Secondary Skills")]
        public string SecondarySkills { get; set; }

        [DisplayName("Report To")]
        public string ReportTo { get; set; }
    }
}
