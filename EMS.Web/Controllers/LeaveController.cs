using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Entities;
using EMS.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LeaveController : Controller
    {
        private readonly AdminRepository adminRepository;
        public LeaveController(AdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        [HttpGet]
        public IActionResult LeaveTypes()
        {
            return View(adminRepository.GetLeaveTypeList());
        }

        [HttpGet]
        public IActionResult CreateLeaveType()
        {
            LeaveType leaveType = new LeaveType();
            return View(leaveType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateLeaveType(LeaveType model)
        {
            if (ModelState.IsValid)
            {
                var leaveType = adminRepository.GetLeaveTypeByName(model.LeaveTypeName);

                if (leaveType != null)
                {
                    TempData["ErrorMessage"] = "This leave type is already exists!";
                    return View(model);
                }

                var addedLeaveType = adminRepository.AddUpdateLeaveType(model);
                if (addedLeaveType != null)
                {
                    TempData["SuccessMessage"] = "Leave type added Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Somthing went wrong. Please try again!";
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditLeaveType(int id)
        {
            return View(adminRepository.GetLeaveTypeById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditLeaveType(LeaveType model)
        {

            var checkLeaveType = adminRepository.GetLeaveTypeByName(model.LeaveTypeName);

            if (checkLeaveType != null)
            {
                if (checkLeaveType == null || checkLeaveType.LeaveTypeId != model.LeaveTypeId)
                {
                    this.TempData["ErrorMessage"] = "This leave type is already exists.";
                    return View(model);
                }
            }
            checkLeaveType = adminRepository.GetLeaveTypeById(model.LeaveTypeId);
            checkLeaveType.LeaveTypeName = model.LeaveTypeName;
            var updatedLeaveType = adminRepository.AddUpdateLeaveType(checkLeaveType);
            if (updatedLeaveType != null)
            {
                this.TempData["SuccessMessage"] = "Leave type updated Successfully";
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLeaveType(int id)
        {
            try
            {
                var result = adminRepository.DeleteLeaveType(id);
                if (result)
                {
                    TempData["SuccessMessage"] = "LeaveType deleted Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Somthing went wrong. Please try again!";
                }
            }
            catch
            {
                this.TempData["ErrorMessage"] = "Somthing went wrong. Please try again!";
            }
            return RedirectToAction("LeaveTypes");
        }
    }
}