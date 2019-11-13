using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Entities
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "Designation name required.")]
        [StringLength(20, ErrorMessage = "The field {0} must be a maximum length of '20'.")]
        [DisplayName("Designation Name")]
        public int DesignationName { get; set; }
    }
}
