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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Holiday Date")]
        public DateTime? HolidayDate { get; set; }

        [Required(ErrorMessage = "Holiday name required.")]
        [DisplayName("Holiday Name")]
        public string HolidayName { get; set; }
    }
}
