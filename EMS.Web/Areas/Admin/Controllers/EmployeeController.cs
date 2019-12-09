using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EMS.Entities;
using EMS.Web.Controllers;
using EMS.Web.Repositories;
using EMS.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : BaseController
    {
        private readonly AdminRepository adminRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly HostingEnvironment hostingEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        public EmployeeRepository employeeRepository { get; }
        string directoryPath = string.Empty;

        public EmployeeController(EmployeeRepository employeeRepository, AdminRepository adminRepository, AccountRepository accountRepository, UserManager<IdentityUser> userManager, HostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor, accountRepository)
        {
            this.employeeRepository = employeeRepository;
            this.adminRepository = adminRepository;
            this.userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            directoryPath = Path.Combine(hostingEnvironment.WebRootPath + "\\Images\\EmployeeImage");
        }

        // GET: Employee
        public IActionResult Index()
        {
            return View(employeeRepository.GetAllEmployees().OrderBy(o => o.EmployeeCode));
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            EmployeeViewModel model = new EmployeeViewModel();
            model.Employee = new Employee();
            model.QualificationList = adminRepository.GetQualificationList();
            model.DesignationList = adminRepository.GetDesignationList();
            model.DepartmentList = adminRepository.GetDepartmentList();

            model.ReportToList = employeeRepository.GetAllActiveEmployees().Select(r => new SelectListItem
            {
                Text = r.FirstName + (r.MiddileName != null ? (" " + r.MiddileName + " " + r.LastName) : (" " + r.LastName)),
                Value = r.EmployeeId.ToString()
            }).ToList();

            return View(model);
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel model)
        {
            ModelState.Remove("Employee.EmployeeId");
            if (ModelState.IsValid)
            {
                var lastEmpCode = 0;
                var activeEmployee = employeeRepository.GetAllEmployees();
                if (activeEmployee.Count > 0)
                {
                    lastEmpCode = activeEmployee.OrderByDescending(o => o.CreatedDate).FirstOrDefault().EmployeeCode;
                }

                model.Employee.EmployeeCode = 101;
                if (lastEmpCode != 0)
                {
                    model.Employee.EmployeeCode = lastEmpCode + 1;
                }

                if (model.ProfileImage != null)
                {
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    string uniqueFileName = model.Employee.EmployeeCode + "$$" + model.ProfileImage.FileName;
                    string filePath = Path.Combine(directoryPath, uniqueFileName);
                    model.ProfileImage.CopyTo(new FileStream(filePath, FileMode.Create));
                    model.Employee.ImagePath = uniqueFileName;
                }
                model.Employee.CreatedBy = LoginUser.UserId.ToString();
                var result = employeeRepository.AddUpdateEmployee(model.Employee);
                if (result != null)
                {
                    TempData["SuccessMessage"] = "Employee added successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong while registering employee!";
                }
            }

            model.QualificationList = adminRepository.GetQualificationList();
            model.DesignationList = adminRepository.GetDesignationList();
            model.DepartmentList = adminRepository.GetDepartmentList();
            model.ReportToList = employeeRepository.GetAllActiveEmployees().Select(r => new SelectListItem
            {
                Text = r.FirstName + (r.MiddileName != null ? (" " + r.MiddileName + " " + r.LastName) : (" " + r.LastName)),
                Value = r.EmployeeId.ToString()
            }).ToList();

            return View(model);
        }

        // GET: Employee/Details/5
        public IActionResult Details(Guid id)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            var employee = employeeRepository.GetEmployeeById(id);
            if (employee != null)
            {
                model.Employee = employee;
                if (employee.ReportTo != null)
                {
                    var reportToEmployee = employeeRepository.GetEmployeeById(Guid.Parse(employee.ReportTo));
                    model.Employee.ReportTo = reportToEmployee.FirstName + (reportToEmployee.MiddileName != null ? (" " + reportToEmployee.MiddileName + " " + reportToEmployee.LastName) : (" " + reportToEmployee.LastName));
                }
            }

            return View(model);
        }

        // GET: Employee/Edit/5
        public IActionResult Edit(Guid id)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            var employee = employeeRepository.GetEmployeeById(id);
            if (employee != null)
            {
                model.Employee = employee;
            }
            model.QualificationList = adminRepository.GetQualificationList();
            model.DesignationList = adminRepository.GetDesignationList();
            model.DepartmentList = adminRepository.GetDepartmentList();
            model.ReportToList = employeeRepository.GetAllActiveEmployees().Where(m => m.EmployeeId != employee.EmployeeId).Select(r => new SelectListItem
            {
                Text = r.FirstName + (r.MiddileName != null ? (" " + r.MiddileName + " " + r.LastName) : (" " + r.LastName)),
                Value = r.EmployeeId.ToString()
            }).ToList();

            return View(model);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel model)
        {
            var employee = new Employee();
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                employee = employeeRepository.GetEmployeeById(model.Employee.EmployeeId);

                if (employee != null)
                {
                    var errorCount = 0;
                    var allActiveEmployee = employeeRepository.GetAllActiveEmployees();
                    var emailFound = allActiveEmployee.Where(m => m.EmailAddress == model.Employee.EmailAddress && m.EmployeeId != model.Employee.EmployeeId);
                    if (emailFound.Count() > 0)
                    {
                        errorCount++;
                        ViewBag.EmailExist = "This email address is already used by another empoyee";
                    }

                    var mobileFound = allActiveEmployee.Where(m => m.MobileNumber == model.Employee.MobileNumber && m.EmployeeId != model.Employee.EmployeeId);
                    if (mobileFound.Count() > 0)
                    {
                        errorCount++;
                        ViewBag.MobileExist = "Mobile number is already used by another employee.";
                    }

                    if (errorCount == 0)
                    {
                        employee.EmployeeId = model.Employee.EmployeeId;
                        employee.EmployeeCode = employee.EmployeeCode;
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
                        employee.ModifiedBy = LoginUser.UserId.ToString();

                        if (employee.ImagePath != null)
                        {
                            string deletedFilePath = Path.Combine(hostingEnvironment.WebRootPath + "\\Images\\EmployeeImage\\" + employee.ImagePath);
                            if (System.IO.File.Exists(deletedFilePath))
                            {
                                System.GC.Collect();
                                System.GC.WaitForPendingFinalizers();
                                System.IO.File.Delete(deletedFilePath);
                            }
                        }

                        if (model.ProfileImage != null)
                        {
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            string uniqueFileName = employee.EmployeeCode + "$$" + model.ProfileImage.FileName;
                            string filePath = Path.Combine(directoryPath, uniqueFileName);
                            model.ProfileImage.CopyTo(new FileStream(filePath, FileMode.Create));
                            employee.ImagePath = uniqueFileName;
                        }
                        else
                        {
                            employee.ImagePath = null;
                        }

                        var result = employeeRepository.AddUpdateEmployee(employee);
                        if (result != null)
                        {
                            TempData["SuccessMessage"] = "Employee updated successfully";
                            return RedirectToAction("Edit", new { id = employee.EmployeeId });
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Something went wrong while updating employee!";
                        }
                    }
                }
            }
            model.QualificationList = adminRepository.GetQualificationList();
            model.DesignationList = adminRepository.GetDesignationList();
            model.DepartmentList = adminRepository.GetDepartmentList();
            model.ReportToList = employeeRepository.GetAllActiveEmployees().Where(m => m.EmployeeId != employee.EmployeeId).Select(r => new SelectListItem
            {
                Text = r.FirstName + (r.MiddileName != null ? (" " + r.MiddileName + " " + r.LastName) : (" " + r.LastName)),
                Value = r.EmployeeId.ToString()
            }).ToList();

            return View(model);
        }

        // GET: Employee/Edit/5
        public IActionResult Deactivate(Guid id)
        {
            var employee = employeeRepository.GetEmployeeById(id);
            if (employee != null)
            {
                employee.IsActive = false;
                employee.IsDeleted = true;
                employee.ModifiedBy = LoginUser.UserId.ToString();

                var result = employeeRepository.AddUpdateEmployee(employee);
                if (result != null)
                {
                    TempData["SuccessMessage"] = "Employee deactivated successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong while deactivating employee!";
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Employee/Edit/5
        public IActionResult Activate(Guid id)
        {
            var employee = employeeRepository.GetEmployeeById(id);
            if (employee != null)
            {
                employee.IsActive = true;
                employee.IsDeleted = false;
                employee.ModifiedBy = LoginUser.UserId.ToString();

                var result = employeeRepository.AddUpdateEmployee(employee);
                if (result != null)
                {
                    TempData["SuccessMessage"] = "Employee activated successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong while deactivating employee!";
                }
            }

            return RedirectToAction("Index");
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var result = employeeRepository.DeleteEmployeeById(id);
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