using EMS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.ViewModels
{
    public class EmployeeLeaveHistoryViewModel
    {
        public string EmployeeFullName { get; set; }

        [DisplayName("No Of Days")]
        public double NoOfLeaves { get; set; }

        [DisplayName("Handover To")]
        public string HandoverToEmployeeName { get; set; }

        public EmployeeLeave EmployeeLeave { get; set; }
    }
}
