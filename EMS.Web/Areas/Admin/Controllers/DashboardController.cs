using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Entities;
using EMS.Web.Repositories;
using EMS.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly AdminRepository adminRepository;
        private readonly EmployeeRepository employeeRepository;

        public DashboardController(AdminRepository adminRepository, EmployeeRepository employeeRepository)
        {
            this.adminRepository = adminRepository;
            this.employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();
            var employeeLeaves = adminRepository.GetEmployeeLeaves();
            model.TotalEmployeeCount = employeeRepository.GetAllActiveEmployees().Count();

            model.TodayLeavesList = employeeLeaves.Where(m => m.StartDate == DateTime.Now.Date).ToList();
            model.TodayLeavePercent = (model.TodayLeavesList.Count * 100) / model.TotalEmployeeCount;

            var upcomingLeaveStartDate = DateTime.Now.Date;
            var upcomingLeaveEndDate = DateTime.Now.AddDays(30).Date;
            model.UpcomingLeavesList = employeeLeaves.Where(m => m.StartDate > upcomingLeaveStartDate && m.EndDate <= upcomingLeaveEndDate).ToList();
            model.UpcomingLeavePercent = (model.UpcomingLeavesList.Count * 100) / model.TotalEmployeeCount;

            return View(model);
        }
    }
}