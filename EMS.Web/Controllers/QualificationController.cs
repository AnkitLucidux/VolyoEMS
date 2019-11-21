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
    [Authorize]
    public class QualificationController : Controller
    {
        private readonly AdminRepository _adminRepository;
        public QualificationController(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_adminRepository.GetQualificationList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            Qualification qualification = new Qualification();
            return View(qualification);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Qualification qualificationModel)
        {
            try
            {
                var checkQualification = _adminRepository.GetQualificationByName(qualificationModel.QualificationName);

                if (checkQualification != null)
                {
                    this.TempData["ErrorMessage"] = "This qualification is already exists!";
                    return View(qualificationModel);
                }

                var addDepartment = _adminRepository.AddUpdateQualification(qualificationModel);
                if (addDepartment != null)
                {
                    this.TempData["SuccessMessage"] = "Qualification added Successfully";
                }
            }
            catch (Exception ex)
            {
                this.TempData["ErrorMessage"] = "Something Went Wrong. Please try again!";
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_adminRepository.GetQualificationById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Qualification qualificationModel)
        {
            try
            {
                var checkQualification = _adminRepository.GetQualificationByName(qualificationModel.QualificationName);

                if (checkQualification != null)
                {
                    if (checkQualification == null || checkQualification.QualificationId != qualificationModel.QualificationId)
                    {
                        this.TempData["ErrorMessage"] = "This qualification is already exists.";
                        return View(qualificationModel);
                    }
                }
                checkQualification = _adminRepository.GetQualificationById(qualificationModel.QualificationId);
                checkQualification.QualificationName = qualificationModel.QualificationName;
                var updateQualification = _adminRepository.AddUpdateQualification(checkQualification);
                if (updateQualification != null)
                {
                    this.TempData["SuccessMessage"] = "Qualification updated Successfully";
                }
            }
            catch (Exception ex)
            {
                this.TempData["ErrorMessage"] = "Somthing went wrong. Please try again!";
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _adminRepository.DeleteQualification(id);
                if (result)
                {
                    this.TempData["SuccessMessage"] = "Qualification deleted Successfully";
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