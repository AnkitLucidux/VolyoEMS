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
        private readonly AdminRepository _adminRepository;
        public HolidayController(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public ActionResult Index()
        {
            return View(_adminRepository.GetAllHolidayList());
        }

        // GET: Holiday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Holiday/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Holiday holidayModel)
        {
            try
            {
                var checkHoliday = _adminRepository.GetHolidayByName(holidayModel.HolidayName);

                if (checkHoliday != null)
                {
                    this.TempData["ErrorMessage"] = "This holiday is already exists!";
                    return View(holidayModel);
                }

                var addHoliday = _adminRepository.AddUpdateHoliday(holidayModel);
                if (addHoliday != null)
                {
                    this.TempData["SuccessMessage"] = "Holiday added Successfully";
                }
            }
            catch (Exception ex)
            {
                this.TempData["ErrorMessage"] = "Something Went Wrong. Please try again!";
                return View();
            }
            return RedirectToAction("Index");
        }

        // GET: Holiday/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Holiday/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Holiday/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Holiday/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}