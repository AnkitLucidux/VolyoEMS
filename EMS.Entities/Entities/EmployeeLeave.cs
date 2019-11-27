using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.Entities
{
    public class EmployeeLeave
    {
        [Key]
        public Guid EmployeeLeaveId { get; set; }

        [Required(ErrorMessage = "Employee is required")]
        [DisplayName("Employee")]
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("Start Date First Half")]
        public bool StartDateFirstHalf { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        [DisplayName("End Date Second Half")]
        public bool EndDateSecondHalf { get; set; }

        public int LeaveTypeId { get; set; }

        [Required(ErrorMessage = "Reason required")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "Handover employee required")]
        [DisplayName("Project Handover To")]
        public Guid HandoverTo { get; set; }

        [Required(ErrorMessage = "Project Description required")]
        [DisplayName("Project Description")]
        public string HandoverProjectDetail { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("LeaveTypeId")]
        public virtual LeaveType LeaveType { get; set; }
    }
}
