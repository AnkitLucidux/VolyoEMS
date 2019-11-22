using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Entities
{
    public class LeaveType
    {
        [Key]
        public int LeaveTypeId { get; set; }

        [Required(ErrorMessage = "Leave type required.")]
        [DisplayName("Leave Type")]
        public string LeaveTypeName { get; set; }
    }
}
