using EMS.Entities;
using EMS.Entities.DBContext;
using EMS.Services.IService;
using EMS.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Repositories
{
    public class AdminRepository
    {
        public IAdminService adminService;

        public AdminRepository(EMSDbContext eMSDbContext)
        {
            adminService = new AdminService(eMSDbContext);
        }

        public List<Department> GetDepartmentList()
        {
            return adminService.GetDepartmentList();
        }

        public Department GetDepartmentByName(string departmentname)
        {
            return adminService.GetDepartmentByName(departmentname);
        }

        public Department AddUpdateDepartment(Department department)
        {
            return adminService.AddUpdateDepartment(department);
        }

        public Department GetDepartmentById(int id)
        {
            return adminService.GetDepartmentById(id);
        }

        public bool DeleteDepartment(int id)
        {
            return adminService.DeleteDepartment(id);
        }

        public List<Designation> GetDesignationList()
        {
            return adminService.GetDesignationList();
        }

        public Designation GetDesignationByName(string designationName)
        {
            return adminService.GetDesignationByName(designationName);
        }

        public Designation AddUpdateDesignation(Designation department)
        {
            return adminService.AddUpdateDesignation(department);
        }

        public Designation GetDesignationById(int id)
        {
            return adminService.GetDesignationById(id);
        }

        public bool DeleteDesignation(int id)
        {
            return adminService.DeleteDesignation(id);
        }

        public List<Qualification> GetQualificationList()
        {
            return adminService.GetQualificationList();
        }

        public Qualification GetQualificationByName(string qualificationName)
        {
            return adminService.GetQualificationByName(qualificationName);
        }

        public Qualification AddUpdateQualification(Qualification qualification)
        {
            return adminService.AddUpdateQualification(qualification);
        }

        public Qualification GetQualificationById(int id)
        {
            return adminService.GetQualificationById(id);
        }

        public bool DeleteQualification(int id)
        {
            return adminService.DeleteQualification(id);
        }

        public List<LeaveType> GetLeaveTypeList()
        {
            return adminService.GetLeaveTypeList();
        }

        public LeaveType GetLeaveTypeByName(string leaveTypeName)
        {
            return adminService.GetLeaveTypeByName(leaveTypeName);
        }

        public LeaveType AddUpdateLeaveType(LeaveType leaveType)
        {
            return adminService.AddUpdateLeaveType(leaveType);
        }

        public LeaveType GetLeaveTypeById(int id)
        {
            return adminService.GetLeaveTypeById(id);
        }

        public bool DeleteLeaveType(int id)
        {
            return adminService.DeleteLeaveType(id);
        }

        public List<Holiday> GetHolidayList()
        {
            return adminService.GetHolidayList();
        }

        public Holiday GetHolidayByDate(DateTime? holidayDate)
        {
            return adminService.GetHolidayByDate(holidayDate);
        }

        public Holiday GetHolidayByName(string holidayName)
        {
            return adminService.GetHolidayByName(holidayName);
        }

        public Holiday AddUpdateHoliday(Holiday holiday)
        {
            return adminService.AddUpdateHoliday(holiday);
        }

        public Holiday GetHolidayById(int id)
        {
            return adminService.GetHolidayById(id);
        }

        public bool DeleteHoliday(int id)
        {
            return adminService.DeleteHoliday(id);
        }

        public List<EmployeeLeaveBalance> GetEmployeeLeaveBalanceList()
        {
            return adminService.GetEmployeeLeaveBalanceList();
        }

        public EmployeeLeaveBalance GetEmployeeLeaveBalanceByEmpIdLeaveTypeId(Guid empId, int leaveTypeId)
        {
            return adminService.GetEmployeeLeaveBalanceByEmpIdLeaveTypeId(empId,leaveTypeId);
        }

        public EmployeeLeaveBalance GetEmployeeLeaveBalanceById(int id)
        {
            return adminService.GetEmployeeLeaveBalanceById(id);
        }

        public EmployeeLeaveBalance AddUpdateEmployeeLeaveBalance(EmployeeLeaveBalance employeeLeaveBalance)
        {
            return adminService.AddUpdateEmployeeLeaveBalance(employeeLeaveBalance);
        }

        public bool DeleteEmployeeLeaveBalance(int id)
        {
            return adminService.DeleteEmployeeLeaveBalance(id);
        }

        public EmployeeLeave ApplyEmployeeLeave(EmployeeLeave employeeLeave)
        {
            return adminService.ApplyEmployeeLeave(employeeLeave);
        }

        public List<EmployeeLeave> GetEmployeeLeavesByEmpId(Guid empId)
        {
            return adminService.GetEmployeeLeavesByEmpId(empId);
        }

        public List<EmployeeLeave> GetEmployeeLeaves()
        {
            return adminService.GetEmployeeLeaves();
        }
    }
}
