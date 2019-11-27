using EMS.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.ViewModels
{
    public class EmployeeLeaveBalanceViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Employees")]
        public List<Employee> EmployeeList { get; set; }

        [DisplayName("Leave Type")]
        public List<SelectListItem> LeaveTypeList { get; set; }

        public EmployeeLeaveBalance EmployeeLeaveBalance { get; set; }
    }
}
