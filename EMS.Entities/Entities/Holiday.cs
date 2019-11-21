using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Entities
{
    public class Holiday
    {
        [Key]
        public int HolidayId { get; set; }

        [Required(ErrorMessage = "Holiday date required.")]
        [DisplayName("Holiday date")]
        public DateTime HolidayDate { get; set; }

        [Required(ErrorMessage = "Holiday name required.")]
        [StringLength(50, ErrorMessage = "The field {0} must be a maximum length of '50'.")]
        [DisplayName("Holiday Name")]
        public string HolidayName { get; set; }
    }
}
