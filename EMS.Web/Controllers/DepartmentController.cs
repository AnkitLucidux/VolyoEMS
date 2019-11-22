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
    public class DepartmentController : Controller
    {
        private readonly AdminRepository _adminRepository;
        public DepartmentController(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_adminRepository.GetDepartmentList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            Department department = new Department();
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department departmentModel)
        {
            try
            {
                var checkDepartment = _adminRepository.GetDepartmentByName(departmentModel.DepartmentName);

                if (checkDepartment != null)
                {
                    this.TempData["ErrorMessage"] = "This Department is already exists!";
                    return View(departmentModel);
                }

                var addDepartment = _adminRepository.AddUpdateDepartment(departmentModel);
                if (addDepartment != null)
                {
                    this.TempData["SuccessMessage"] = "Department Added Successfully";
                }
            }
            catch (Exception ex)
            {
                this.TempData["ErrorMessage"] = "Something Went Wrong. Please try again!";
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_adminRepository.GetDepartmentById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department departmentModel)
        {
            try
            {
                var checkDepartment = _adminRepository.GetDepartmentByName(departmentModel.DepartmentName);

                if (checkDepartment != null)
                {
                    if (checkDepartment == null || checkDepartment.DepartmentId != departmentModel.DepartmentId)
                    {
                        this.TempData["ErrorMessage"] = "This Department is already exists.";
                        return View(departmentModel);
                    }
                }
                checkDepartment = _adminRepository.GetDepartmentById(departmentModel.DepartmentId);
                checkDepartment.DepartmentName = departmentModel.DepartmentName;
                var updateDepartment = _adminRepository.AddUpdateDepartment(checkDepartment);
                if (updateDepartment != null)
                {
                    this.TempData["SuccessMessage"] = "Department Updated Successfully";
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
                var result = _adminRepository.DeleteDepartment(id);
                if (result)
                {
                    TempData["SuccessMessage"] = "Department deleted Successfully";
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