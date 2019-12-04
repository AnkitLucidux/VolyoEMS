using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Entities;
using EMS.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HolidayController : Controller
    {
        private readonly AdminRepository adminRepository;
        public HolidayController(AdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public ActionResult Index()
        {
            return View(adminRepository.GetHolidayList().OrderBy(o => o.HolidayDate));
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
            if (ModelState.IsValid)
            {
                if (holidayModel.HolidayDate.Value.DayOfWeek == DayOfWeek.Saturday || holidayModel.HolidayDate.Value.DayOfWeek == DayOfWeek.Sunday)
                {
                    ViewBag.WeekendExist = "You can not apply holiday on weekend.";
                    return View(holidayModel);
                }

                var errorCount = 0;
                var checkHolidayByDate = adminRepository.GetHolidayByDate(holidayModel.HolidayDate);
                var checkholidayByName = adminRepository.GetHolidayByName(holidayModel.HolidayName);

                if (checkHolidayByDate != null)
                {
                    if (checkHolidayByDate.HolidayDate == holidayModel.HolidayDate)
                    {
                        errorCount++;
                        ViewBag.DateExistsError = $"{holidayModel.HolidayDate.Value.ToString("dd-MMM-yyyy")} is already occupied with another holiday!";
                    }
                }

                if (checkholidayByName != null)
                {
                    if (checkholidayByName.HolidayName == holidayModel.HolidayName)
                    {
                        errorCount++;
                        ViewBag.NameExistsError = $"{holidayModel.HolidayName} is already exists!";
                    }
                }

                if (errorCount == 0)
                {
                    var addedHoliday = adminRepository.AddUpdateHoliday(holidayModel);
                    if (addedHoliday != null)
                    {
                        this.TempData["SuccessMessage"] = "Holiday added Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Somthing went wrong. Please try again!";
                    }
                    return RedirectToAction("Index");
                }
            }
            else
            {
                this.TempData["ErrorMessage"] = "Somthing went wrong. Please try again!";
            }

            return View(holidayModel);
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
            if (ModelState.IsValid)
            {
                if (model.HolidayDate.Value.DayOfWeek == DayOfWeek.Saturday || model.HolidayDate.Value.DayOfWeek == DayOfWeek.Sunday)
                {
                    ViewBag.WeekendExist = "You can not apply holiday on weekend.";
                    return View(model);
                }

                var errorCount = 0;
                var checkHolidayByDate = adminRepository.GetHolidayByDate(model.HolidayDate);
                var checkHolidayByName = adminRepository.GetHolidayByName(model.HolidayName);
                if (checkHolidayByDate != null)
                {
                    if (checkHolidayByDate == null || checkHolidayByDate.HolidayId != model.HolidayId)
                    {
                        if (checkHolidayByDate.HolidayDate == model.HolidayDate)
                        {
                            errorCount++;
                            ViewBag.DateExistsError = $"{model.HolidayDate.Value.ToString("dd-MMM-yyyy")} is already occupied with another holiday!";
                        }
                    }
                }

                if (checkHolidayByName != null)
                {
                    if (checkHolidayByName == null || checkHolidayByName.HolidayId != model.HolidayId)
                    {
                        if (checkHolidayByName.HolidayName == model.HolidayName)
                        {
                            errorCount++;
                            ViewBag.NameExistsError = $"{model.HolidayName} is already exists!";
                        }
                    }
                }
                if (errorCount == 0)
                {
                    checkHolidayByName = adminRepository.GetHolidayById(model.HolidayId);
                    checkHolidayByName.HolidayName = model.HolidayName;
                    checkHolidayByName.HolidayDate = model.HolidayDate;
                    var updatedHoliday = adminRepository.AddUpdateHoliday(checkHolidayByName);
                    if (updatedHoliday != null)
                    {
                        TempData["SuccessMessage"] = "Holiday updated Successfully";
                        return RedirectToAction("Index");
                    }
                }
            }
            else
            {
                this.TempData["ErrorMessage"] = "This holiday is already exists.";
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteHoliday(int id)
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