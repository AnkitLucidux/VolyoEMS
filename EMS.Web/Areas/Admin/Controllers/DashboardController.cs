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

            var todayDate = DateTime.Now.Date;
            model.TodayLeavesList = employeeLeaves.Where(m => m.StartDate.Date <= todayDate && m.EndDate.Date >= todayDate).ToList();
            model.TodayLeavePercent = (model.TodayLeavesList.Count * 100) / model.TotalEmployeeCount;

            var upcomingLeaveStartDate = DateTime.Today.AddDays(1).Date;
            var upcomingLeaveEndDate = DateTime.Today.AddDays(30).Date;
            model.UpcomingLeavesList = employeeLeaves.Where(m => (m.StartDate.Date <= upcomingLeaveStartDate && m.EndDate.Date >= upcomingLeaveStartDate)  && m.EndDate.Date <= upcomingLeaveEndDate).ToList();
            model.UpcomingLeavePercent = (model.UpcomingLeavesList.Count * 100) / model.TotalEmployeeCount;

            return View(model);
        }
    }
}