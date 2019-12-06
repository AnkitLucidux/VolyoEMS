using EMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalEmployeeCount { get; set; }

        public decimal TodayLeavePercent { get; set; }

        public decimal UpcomingLeavePercent { get; set; }

        public List<EmployeeLeave> TodayLeavesList { get; set; }

        public List<EmployeeLeave> UpcomingLeavesList { get; set; }
    }
}
