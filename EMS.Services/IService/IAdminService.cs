using EMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Services.IService
{
    public interface IAdminService
    {
        List<Department> GetDepartmentList();
        Department GetDepartmentByName(string departmentname);
        Department AddUpdateDepartment(Department department);
        Department GetDepartmentById(int id);
        bool DeleteDepartment(int id);

        List<Designation> GetDesignationList();
        Designation GetDesignationByName(string designationName);
        Designation AddUpdateDesignation(Designation department);
        Designation GetDesignationById(int id);
        bool DeleteDesignation(int id);

        List<Qualification> GetQualificationList();
        Qualification GetQualificationByName(string qualificationName);
        Qualification AddUpdateQualification(Qualification qualification);
        Qualification GetQualificationById(int id);
        bool DeleteQualification(int id);

        List<LeaveType> GetLeaveTypeList();
        LeaveType GetLeaveTypeByName(string leaveTypeName);
        LeaveType AddUpdateLeaveType(LeaveType leaveType);
        LeaveType GetLeaveTypeById(int id);
        bool DeleteLeaveType(int id);

        List<Holiday> GetHolidayList();
        Holiday GetHolidayByName(string holidayName);
        Holiday AddUpdateHoliday(Holiday holiday);
        Holiday GetHolidayById(int id);
        bool DeleteHoliday(int id);
    }
}
