using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Entities;
using EMS.Web.Repositories;
using EMS.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AdminRepository adminRepository;

        public EmployeeViewModelRepository employeeViewModelRepository { get; }

        public EmployeeController(EmployeeViewModelRepository employeeViewModelRepository, AdminRepository adminRepository)
        {
            this.employeeViewModelRepository = employeeViewModelRepository;
            this.adminRepository = adminRepository;
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View(employeeViewModelRepository.GetAllEmployees());
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            EmployeeViewModel model = new EmployeeViewModel();
            model.QualificationList = adminRepository.GetQualificationList();
            model.DesignationList = adminRepository.GetDesignationList();
            model.DepartmentList = adminRepository.GetDepartmentList();

            return View(model);
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel model)
        {
            var result = employeeViewModelRepository.AddUpdateEmployee(model.Employee);
            if (result != null)
            {
                TempData["SuccessMessage"] = "Employee added successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Something went wrong while registering employee!";
            }

            model.QualificationList = adminRepository.GetQualificationList();
            model.DesignationList = adminRepository.GetDesignationList();
            model.DepartmentList = adminRepository.GetDepartmentList();

            return View(model);
        }


        // GET: Employee/Details/5
        public ActionResult Details(Guid id)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            var employee = employeeViewModelRepository.GetEmployeeById(id);
            if (employee != null)
            {
                model.Employee = employee;
            }

            return View(model);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(Guid id)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            var employee = employeeViewModelRepository.GetEmployeeById(id);
            if (employee != null)
            {
                model.Employee = employee;
            }
            model.QualificationList = adminRepository.GetQualificationList();
            model.DesignationList = adminRepository.GetDesignationList();
            model.DepartmentList = adminRepository.GetDepartmentList();

            return View(model);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel model)
        {
            var employee = employeeViewModelRepository.GetEmployeeById(model.Employee.EmployeeId);
            if (employee != null)
            {
                employee.EmployeeId = model.Employee.EmployeeId;
                employee.EmployeeCode = model.Employee.EmployeeCode;
                employee.FirstName = model.Employee.FirstName;
                employee.MiddileName = model.Employee.MiddileName;
                employee.LastName = model.Employee.LastName;
                employee.Gender = model.Employee.Gender;
                employee.DOB = model.Employee.DOB;
                employee.EmailAddress = model.Employee.EmailAddress;
                employee.FatherName = model.Employee.FatherName;
                employee.MotherName = model.Employee.MotherName;
                employee.PermanentAddress = model.Employee.PermanentAddress;
                employee.CommunicationAddress = model.Employee.CommunicationAddress;
                employee.PhoneNumber = model.Employee.PhoneNumber;
                employee.MobileNumber = model.Employee.MobileNumber;
                employee.AadharNumber = model.Employee.AadharNumber;
                employee.PanNumber = model.Employee.PanNumber;
                employee.PassportNumber = model.Employee.PassportNumber;
                employee.PassportExpDate = model.Employee.PassportExpDate;
                employee.MaritalStatus = model.Employee.MaritalStatus;
                employee.QualificationId = model.Employee.QualificationId;
                employee.DepartmentId = model.Employee.DepartmentId;
                employee.DesignationId = model.Employee.DesignationId;
                employee.JoiningDate = model.Employee.JoiningDate;
                employee.TotalExperience = model.Employee.TotalExperience;
                employee.PastExperience = model.Employee.PastExperience;
                employee.PrimarySkills = model.Employee.PrimarySkills;
                employee.SecondarySkills = model.Employee.SecondarySkills;
                employee.ReportTo = model.Employee.ReportTo;

                var result = employeeViewModelRepository.AddUpdateEmployee(employee);
                if (result != null)
                {
                    TempData["SuccessMessage"] = "Employee updated successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong while updating employee!";
                }
            }

            model.QualificationList = adminRepository.GetQualificationList();
            model.DesignationList = adminRepository.GetDesignationList();
            model.DepartmentList = adminRepository.GetDepartmentList();

            return View(model);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var result = employeeViewModelRepository.DeleteEmployeeById(id);
                if (result)
                {
                    TempData["SuccessMessage"] = "Employee deleted Successfully";
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