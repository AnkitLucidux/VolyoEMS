using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department name required.")]
        [StringLength(20, ErrorMessage = "The field {0} must be a maximum length of '20'.")]
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }

    }
}
