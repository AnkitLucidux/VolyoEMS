﻿using System;
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
    public class DesignationController : Controller
    {
        private readonly AdminRepository _adminRepository;
        public DesignationController(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        // GET: Designation
        public IActionResult Index()
        {
            return View(_adminRepository.GetDesignationList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            Designation designation = new Designation();
            return View(designation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Designation designationModel)
        {
            try
            {
                var checkDepartment = _adminRepository.GetDesignationByName(designationModel.DesignationName);

                if (checkDepartment != null)
                {
                    this.TempData["ErrorMessage"] = "This Designation is already exists!";
                    return View(designationModel);
                }

                var addDepartment = _adminRepository.AddUpdateDesignation(designationModel);
                if (addDepartment != null)
                {
                    this.TempData["SuccessMessage"] = "Designation Added Successfully";
                }
            }
            catch (Exception ex)
            {
                this.TempData["ErrorMessage"] = "Something Went Wrong. Please try again!";
                return View(designationModel);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Designation/Edit/5
        public IActionResult Edit(int id)
        {
            return View(_adminRepository.GetDesignationById(id));
        }

        // POST: Designation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Designation designationModel)
        {
            try
            {
                var checkDesignation = _adminRepository.GetDesignationByName(designationModel.DesignationName);

                if (checkDesignation != null)
                {
                    if (checkDesignation == null || checkDesignation.DesignationId != designationModel.DesignationId)
                    {
                        this.TempData["ErrorMessage"] = "This Designation is already exists.";
                        return View(designationModel);
                    }
                }
                checkDesignation = _adminRepository.GetDesignationById(designationModel.DesignationId);
                checkDesignation.DesignationName = designationModel.DesignationName;
                var updateDesignation = _adminRepository.AddUpdateDesignation(checkDesignation);
                if (updateDesignation != null)
                {
                    this.TempData["SuccessMessage"] = "Designation Updated Successfully";
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
                var result = _adminRepository.DeleteDesignation(id);
                if (result)
                {
                    TempData["SuccessMessage"] = "Designation deleted Successfully";
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
            return RedirectToAction(nameof(Index));
        }
    }
}