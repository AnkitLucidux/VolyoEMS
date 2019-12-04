using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Entities;
using EMS.Web.Repositories;
using EMS.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LeaveController : Controller
    {
        private readonly AdminRepository adminRepository;
        private readonly EmployeeViewModelRepository employeeViewModelRepository;

        public LeaveController(AdminRepository adminRepository, EmployeeViewModelRepository employeeViewModelRepository)
        {
            this.adminRepository = adminRepository;
            this.employeeViewModelRepository = employeeViewModelRepository;
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

        [HttpGet]
        public IActionResult LeaveBalances()
        {
            return View(adminRepository.GetEmployeeLeaveBalanceList());
        }

        [HttpGet]
        public IActionResult CreateLeaveBalance()
        {
            EmployeeLeaveBalanceViewModel employeeLeaveBalanceViewModel = new EmployeeLeaveBalanceViewModel();

            var leaveBalancesEmployee = adminRepository.GetEmployeeLeaveBalanceList();
            var allActiveEmployee = employeeViewModelRepository.GetAllActiveEmployees();

            employeeLeaveBalanceViewModel.EmployeeList = allActiveEmployee.Where(m => !leaveBalancesEmployee.Any(s => s.Employee.EmailAddress == m.EmailAddress)).ToList();
            if (employeeLeaveBalanceViewModel.EmployeeList.Count <= 0)
            {
                TempData["ErrorMessage"] = "All employee leave balance is occupied, You can update existing employee leave balance or delete to create new.";
                return RedirectToAction("LeaveBalances");
            }

            employeeLeaveBalanceViewModel.LeaveTypeList = adminRepository.GetLeaveTypeList().Select(l => new SelectListItem
            {
                Text = l.LeaveTypeName,
                Value = l.LeaveTypeId.ToString()
            }).OrderBy(o => o.Value).ToList();

            return View(employeeLeaveBalanceViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateLeaveBalance(EmployeeLeaveBalanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var leaveTypes = adminRepository.GetLeaveTypeByName("CL");
                model.EmployeeLeaveBalance.LeaveTypeId = adminRepository.GetLeaveTypeByName("CL").LeaveTypeId;
                var addedLeaveBalance = adminRepository.AddUpdateEmployeeLeaveBalance(model.EmployeeLeaveBalance);
                if (addedLeaveBalance != null)
                {
                    TempData["SuccessMessage"] = "Leave balance added Successfully";
                    return RedirectToAction("LeaveBalances");
                }
                else
                {
                    TempData["ErrorMessage"] = "Somthing went wrong. Please try again!";
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditLeaveBalance(int id)
        {
            EmployeeLeaveBalanceViewModel model = new EmployeeLeaveBalanceViewModel();
            if (ModelState.IsValid)
            {
                model = new EmployeeLeaveBalanceViewModel();
                model.EmployeeLeaveBalance = adminRepository.GetEmployeeLeaveBalanceById(id);
            }
            model.LeaveTypeList = adminRepository.GetLeaveTypeList().Select(l => new SelectListItem
            {
                Text = l.LeaveTypeName,
                Value = l.LeaveTypeId.ToString()
            }).OrderBy(o => o.Value).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditLeaveBalance(EmployeeLeaveBalanceViewModel model)
        {
            var checkedLeaveBalance = adminRepository.GetEmployeeLeaveBalanceById(model.EmployeeLeaveBalance.LeaveBalanceId);

            if (checkedLeaveBalance != null && checkedLeaveBalance.EmployeeId == model.EmployeeLeaveBalance.EmployeeId)
            {
                checkedLeaveBalance.LeaveBalanceId = model.EmployeeLeaveBalance.LeaveBalanceId;
                checkedLeaveBalance.EmployeeId = model.EmployeeLeaveBalance.EmployeeId;
                checkedLeaveBalance.LeaveBalance = model.EmployeeLeaveBalance.LeaveBalance;

                var updatedLeaveBalance = adminRepository.AddUpdateEmployeeLeaveBalance(checkedLeaveBalance);
                if (updatedLeaveBalance != null)
                {
                    this.TempData["SuccessMessage"] = "Leave type updated Successfully";
                    return RedirectToAction("LeaveBalances");
                }
                else
                {
                    TempData["ErrorMessage"] = "Somthing went wrong. Please try again!";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Somthing went wrong. Please try again!";
            }

            model.LeaveTypeList = adminRepository.GetLeaveTypeList().Select(l => new SelectListItem
            {
                Text = l.LeaveTypeName,
                Value = l.LeaveTypeId.ToString()
            }).OrderBy(o => o.Value).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLeaveBalance(int id)
        {
            try
            {
                var result = adminRepository.DeleteEmployeeLeaveBalance(id);
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
            return RedirectToAction("LeaveBalances");
        }

        [HttpGet]
        public IActionResult ApplyLeave()
        {
            LeaveViewModel model = new LeaveViewModel();

            var activeEmployees = employeeViewModelRepository.GetAllActiveEmployees();

            model.EmployeeList = activeEmployees.Select(emp => new SelectListItem
            {
                Text = emp.FirstName + (emp.MiddileName != null ? (" " + emp.MiddileName + " " + emp.LastName) : (" " + emp.LastName)),
                Value = emp.EmployeeId.ToString()
            }).OrderBy(o => o.Value).ToList();

            model.LeaveTypeList = adminRepository.GetLeaveTypeList().Select(l => new SelectListItem
            {
                Text = l.LeaveTypeName,
                Value = l.LeaveTypeId.ToString()
            }).OrderBy(o => o.Value).ToList();

            model.HandoverEmployeeList = activeEmployees.Select(emp => new SelectListItem
            {
                Text = emp.FirstName + (emp.MiddileName != null ? (" " + emp.MiddileName + " " + emp.LastName) : (" " + emp.LastName)),
                Value = emp.EmployeeId.ToString()
            }).OrderBy(o => o.Value).ToList();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ApplyLeave(LeaveViewModel model)
        {

            var activeEmployees = employeeViewModelRepository.GetAllActiveEmployees();

            model.EmployeeList = activeEmployees.Select(emp => new SelectListItem
            {
                Text = emp.FirstName + (emp.MiddileName != null ? (" " + emp.MiddileName + " " + emp.LastName) : (" " + emp.LastName)),
                Value = emp.EmployeeId.ToString()
            }).OrderBy(o => o.Value).ToList();

            model.LeaveTypeList = adminRepository.GetLeaveTypeList().Select(l => new SelectListItem
            {
                Text = l.LeaveTypeName,
                Value = l.LeaveTypeId.ToString()
            }).OrderBy(o => o.Value).ToList();

            model.HandoverEmployeeList = activeEmployees.Select(emp => new SelectListItem
            {
                Text = emp.FirstName + (emp.MiddileName != null ? (" " + emp.MiddileName + " " + emp.LastName) : (" " + emp.LastName)),
                Value = emp.EmployeeId.ToString()
            }).OrderBy(o => o.Value).ToList();

            if (ModelState.IsValid)
            {
                if (model.EmployeeLeave.StartDate.DayOfWeek == DayOfWeek.Saturday || model.EmployeeLeave.StartDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    TempData["ErrorMessage"] = "Start date can not start from weekend.";
                    return View(model);
                }

                if (model.EmployeeLeave.EndDate.DayOfWeek == DayOfWeek.Saturday || model.EmployeeLeave.EndDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    TempData["ErrorMessage"] = "End date can not end to weekend.";
                    return View(model);
                }

                var holidayList = adminRepository.GetHolidayList();
                if (holidayList.Count > 0)
                {
                    var startDateExistsOnHoliday = holidayList.Exists(m => m.HolidayDate == model.EmployeeLeave.StartDate.Date);

                    if (startDateExistsOnHoliday)
                    {
                        TempData["ErrorMessage"] = "Start date can not start from national holidays.";
                        return View(model);
                    }

                    var endDateExistsOnHoliday = holidayList.Exists(m => m.HolidayDate == model.EmployeeLeave.EndDate.Date);

                    if (endDateExistsOnHoliday)
                    {
                        TempData["ErrorMessage"] = "End date can not end to national holidays.";
                        return View(model);
                    }
                }

                if (DateTime.Today.Subtract(model.EmployeeLeave.StartDate).Days > 7)
                {
                    TempData["ErrorMessage"] = "You can not apply leave less than 7 days from today.";
                    return View(model);
                }

                var employeeLeaves = adminRepository.GetEmployeeLeavesByEmpId(model.EmployeeLeave.EmployeeId).Where(m => m.StartDate >= model.EmployeeLeave.StartDate && m.EndDate <= model.EmployeeLeave.EndDate).OrderBy(o => o.StartDate).ToList();

                if (employeeLeaves.Count > 0)
                {
                    var leaveAlreadyExist = employeeLeaves.Exists(m => m.StartDateFirstHalf == model.EmployeeLeave.StartDateFirstHalf || m.EndDateSecondHalf == model.EmployeeLeave.EndDateSecondHalf);
                    if (leaveAlreadyExist)
                    {
                        TempData["ErrorMessage"] = "You have already applied leave for selected dates.";
                        return View(model);
                    }
                }

                var selectedLeaveType = adminRepository.GetLeaveTypeById(model.EmployeeLeave.LeaveTypeId);

                var selectedEmployeeLeaveBalance = new EmployeeLeaveBalance();
                var noOfLeaves = 0.0;
                if (selectedLeaveType.LeaveTypeName.ToUpper() != "LWP")
                {
                    selectedEmployeeLeaveBalance = adminRepository.GetEmployeeLeaveBalanceByEmpIdLeaveTypeId(model.EmployeeLeave.EmployeeId, model.EmployeeLeave.LeaveTypeId);
                    if (selectedEmployeeLeaveBalance == null)
                    {
                        TempData["ErrorMessage"] = $"You dont't have any {model.EmployeeLeave.LeaveType.LeaveTypeName}.";
                        return View(model);
                    }
                    else
                    {
                        noOfLeaves = (model.EmployeeLeave.EndDate.Subtract(model.EmployeeLeave.StartDate)).TotalDays;//2

                        if (model.EmployeeLeave.StartDateFirstHalf && !model.EmployeeLeave.EndDateSecondHalf)
                        {
                            noOfLeaves += 0.5;
                        }
                        else if (!model.EmployeeLeave.StartDateFirstHalf && model.EmployeeLeave.EndDateSecondHalf)
                        {
                            noOfLeaves += 0.5;
                        }

                        if (model.EmployeeLeave.StartDate == model.EmployeeLeave.EndDate)
                        {
                            if ((model.EmployeeLeave.StartDateFirstHalf && model.EmployeeLeave.EndDateSecondHalf) || (!model.EmployeeLeave.StartDateFirstHalf && !model.EmployeeLeave.EndDateSecondHalf))
                            {
                                noOfLeaves += 1;
                            }
                        }
                        else
                        {
                            if (!model.EmployeeLeave.StartDateFirstHalf && !model.EmployeeLeave.EndDateSecondHalf)
                            {
                                noOfLeaves += 1;
                            }
                        }

                        DateTime leaveStartDate = model.EmployeeLeave.StartDate;
                        DateTime leaveEndDate = model.EmployeeLeave.EndDate;

                        TimeSpan diff = leaveEndDate - leaveStartDate;

                        for (var i = 0; i <= diff.Days; i++)
                        {
                            var date = leaveStartDate.AddDays(i);
                            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                            {
                                noOfLeaves -= 1;
                            }

                            if (holidayList.Exists(m => m.HolidayDate == date))
                            {
                                noOfLeaves -= 1;
                            }
                        }

                        if (selectedEmployeeLeaveBalance.LeaveBalance < Convert.ToDecimal(noOfLeaves))
                        {
                            TempData["ErrorMessage"] = $"You dont't have enough {Convert.ToDecimal(noOfLeaves)} leaves of type {model.EmployeeLeave.LeaveType}.";
                            return View(model);
                            //selectedEmployeeLeaveBalance.LeaveBalance -= Convert.ToDecimal(noOfLeaves);
                            //update
                        }
                    }
                }

                var addedLeave = adminRepository.ApplyEmployeeLeave(model.EmployeeLeave);
                if (addedLeave != null)
                {
                    if (selectedLeaveType.LeaveTypeName.ToUpper() != "LWP")
                    {
                        selectedEmployeeLeaveBalance.LeaveBalance -= Convert.ToDecimal(noOfLeaves);

                        //Updating employee leave balance
                        adminRepository.AddUpdateEmployeeLeaveBalance(selectedEmployeeLeaveBalance);
                    }
                    TempData["SuccessMessage"] = "Leave applied successfully";
                    return RedirectToAction("EmployeeLeaveHistory");
                }
                else
                {
                    TempData["ErrorMessage"] = "Somthing went wrong. Please try again!";
                }

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EmployeeLeaveHistory()
        {
            var employeeLeaves = adminRepository.GetEmployeeLeaves().OrderBy(o => o.StartDate);

            List<EmployeeLeaveHistoryViewModel> employeeLeaveHistoryViewModelList = new List<EmployeeLeaveHistoryViewModel>();
            foreach (var leave in employeeLeaves)
            {
                EmployeeLeaveHistoryViewModel employeeLeaveHistoryViewModel = new EmployeeLeaveHistoryViewModel();
                employeeLeaveHistoryViewModel.EmployeeFullName = leave.Employee.FirstName + (leave.Employee.MiddileName != null ? (" " + leave.Employee.MiddileName + " " + leave.Employee.LastName) : (" " + leave.Employee.LastName));
                employeeLeaveHistoryViewModel.EmployeeLeave = leave;
                var handoverEmployee = employeeViewModelRepository.GetEmployeeById(leave.HandoverTo);
                employeeLeaveHistoryViewModel.HandoverToEmployeeName = handoverEmployee.FirstName + (handoverEmployee.MiddileName != null ? (" " + handoverEmployee.MiddileName + " " + handoverEmployee.LastName) : (" " + handoverEmployee.LastName)); ;
                employeeLeaveHistoryViewModel.NoOfLeaves = (leave.EndDate.Subtract(leave.StartDate)).TotalDays;
                if (leave.StartDateFirstHalf && !leave.EndDateSecondHalf)
                {
                    employeeLeaveHistoryViewModel.NoOfLeaves += 0.5;
                }
                else if (!leave.StartDateFirstHalf && leave.EndDateSecondHalf)
                {
                    employeeLeaveHistoryViewModel.NoOfLeaves += 0.5;
                }

                if (leave.StartDate == leave.EndDate)
                {
                    if ((leave.StartDateFirstHalf && leave.EndDateSecondHalf) || (!leave.StartDateFirstHalf && !leave.EndDateSecondHalf))
                    {
                        employeeLeaveHistoryViewModel.NoOfLeaves += 1;
                    }
                }
                else
                {
                    if (!leave.StartDateFirstHalf && !leave.EndDateSecondHalf)
                    {
                        employeeLeaveHistoryViewModel.NoOfLeaves += 1;
                    }
                }

                DateTime leaveStartDate = leave.StartDate;
                DateTime leaveEndDate = leave.EndDate;

                TimeSpan diff = leaveEndDate - leaveStartDate;

                for (var i = 0; i <= diff.Days; i++)
                {
                    var date = leaveStartDate.AddDays(i);
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        employeeLeaveHistoryViewModel.NoOfLeaves -= 1;
                    }

                    if (adminRepository.GetHolidayList().Exists(m => m.HolidayDate == date))
                    {
                        employeeLeaveHistoryViewModel.NoOfLeaves -= 1;
                    }
                }

                employeeLeaveHistoryViewModelList.Add(employeeLeaveHistoryViewModel);
            }
            return View(employeeLeaveHistoryViewModelList);
        }

        [HttpPost]
        public JsonResult GetHandoverEmployeeList(string empId)
        {
            Guid employeeId = Guid.Parse(empId);

            List<SelectListItem> handOverEmployeeList = employeeViewModelRepository.GetAllActiveEmployees().Where(m => m.EmployeeId != employeeId).Select(emp => new SelectListItem
            {
                Text = emp.FirstName + (emp.MiddileName != null ? (" " + emp.MiddileName + " " + emp.LastName) : (" " + emp.LastName)),
                Value = emp.EmployeeId.ToString()
            }).ToList();
            var result = JsonConvert.SerializeObject(handOverEmployeeList);

            return Json(result);
        }

        public JsonResult GetHolidayList()
        {
            List<string> holidayStringList = new List<string>();

            var holidayList = adminRepository.GetHolidayList();

            foreach (var item in holidayList)
            {
                holidayStringList.Add(item.HolidayDate.Value.ToString("d-M-yyyy"));
            }

            var result = JsonConvert.SerializeObject(holidayStringList);
            return Json(result);
        }
    }
}