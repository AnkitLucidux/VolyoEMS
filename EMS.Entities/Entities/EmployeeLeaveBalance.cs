using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Entities
{
    public class EmployeeLeaveBalance
    {
        [Key]
        public int LeaveBalanceId { get; set; }

        public Guid EmployeeId { get; set; }

        [DisplayName("Leave Type")]
        public int LeaveTypeId { get; set; }

        [Required(ErrorMessage = "Leave balance is required")]
        [DisplayName("Leave Balance")]
        public decimal? LeaveBalance { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("LeaveTypeId")]
        public virtual LeaveType LeaveType{ get; set; }
    }
}
