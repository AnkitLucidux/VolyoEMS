using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Entities;
using EMS.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    public class HolidayController : Controller
    {
        private readonly AdminRepository adminRepository;
        public HolidayController(AdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public ActionResult Index()
        {
            return View(adminRepository.GetHolidayList());
        }

        // GET: Holiday/Create
        public ActionResult Create()
        {
            Holiday holiday = new Holiday();
            return View(holiday);
        }

        // POST: Holiday/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Holiday holidayModel)
        {
            var checkHoliday = adminRepository.GetHolidayByName(holidayModel.HolidayName);

            if (checkHoliday != null)
            {
                this.TempData["ErrorMessage"] = "This holiday is already exists!";
                return View(holidayModel);
            }

            var addedHoliday = adminRepository.AddUpdateHoliday(holidayModel);
            if (addedHoliday != null)
            {
                this.TempData["SuccessMessage"] = "Holiday added Successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Somthing went wrong. Please try again!";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(adminRepository.GetHolidayById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Holiday model)
        {

            var checkHoliday = adminRepository.GetHolidayByName(model.HolidayName);

            if (checkHoliday != null)
            {
                if (checkHoliday == null || checkHoliday.HolidayId != model.HolidayId)
                {
                    this.TempData["ErrorMessage"] = "This holiday is already exists.";
                    return View(model);
                }
            }

            checkHoliday = adminRepository.GetHolidayById(model.HolidayId);
            checkHoliday.HolidayName = model.HolidayName;
            var updatedHoliday = adminRepository.AddUpdateHoliday(checkHoliday);
            if (updatedHoliday != null)
            {
                this.TempData["SuccessMessage"] = "Holiday updated Successfully";
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLeaveType(int id)
        {
            try
            {
                var result = adminRepository.DeleteHoliday(id);
                if (result)
                {
                    TempData["SuccessMessage"] = "Holiday deleted Successfully";
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
            return RedirectToAction("Index");
        }
    }
}