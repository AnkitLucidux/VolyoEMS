using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Entities
{
    public class Qualification
    {
        [Key]
        public int QualificationId { get; set; }

        [Required(ErrorMessage = "Qualification name required.")]
        [StringLength(20, ErrorMessage = "The field {0} must be a maximum length of '20'.")]
        [DisplayName("Qualification Name")]
        public string QualificationName { get; set; }
    }
}
