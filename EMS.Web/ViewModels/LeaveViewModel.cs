using EMS.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.ViewModels
{
    public class LeaveViewModel
    {
        public EmployeeLeave EmployeeLeave { get; set; }

        public List<SelectListItem> EmployeeList { get; set; }

        public List<SelectListItem> LeaveTypeList { get; set; }

        public List<SelectListItem> HandoverEmployeeList { get; set; }
    }
}
