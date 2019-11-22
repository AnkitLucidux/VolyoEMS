using EMS.Entities;
using EMS.Entities.DBContext;
using EMS.Services.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMS.Services.Service
{
    public class AdminService : IAdminService
    {
        private readonly EMSDbContext context;
        public AdminService(EMSDbContext emsDbContext)
        {
            context = emsDbContext;
        }

        public List<Department> GetDepartmentList()
        {
            return context.Departments.ToList();
        }

        public Department GetDepartmentByName(string departmentname)
        {
            return context.Departments.FirstOrDefault(x => x.DepartmentName == departmentname);
        }

        public Department AddUpdateDepartment(Department department)
        {
            if (default(int) == department.DepartmentId)
            {
                context.Departments.Add(department);
            }
            else
            {
                context.Entry(department).State = EntityState.Modified;
            }
            context.SaveChanges();
            return department;
        }

        public Department GetDepartmentById(int id)
        {
            return context.Departments.FirstOrDefault(x => x.DepartmentId == id);
        }

        public bool DeleteDepartment(int id)
        {
            var deleteDepartment = context.Departments.FirstOrDefault(x => x.DepartmentId == id);
            try
            {
                if (deleteDepartment != null)
                {
                    context.Departments.Remove(deleteDepartment);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Designation> GetDesignationList()
        {
            return context.Designations.ToList();
        }

        public Designation GetDesignationByName(string designationName)
        {
            return context.Designations.FirstOrDefault(x => x.DesignationName == designationName);
        }

        public Designation GetDesignationById(int id)
        {
            return context.Designations.FirstOrDefault(x => x.DesignationId == id);
        }

        public Designation AddUpdateDesignation(Designation designation)
        {
            if (default(int) == designation.DesignationId)
            {
                context.Designations.Add(designation);
            }
            else
            {
                context.Entry(designation).State = EntityState.Modified;
            }
            context.SaveChanges();
            return designation;
        }

        public bool DeleteDesignation(int id)
        {
            var deleteDesignation = context.Designations.FirstOrDefault(x => x.DesignationId == id);
            try
            {
                if (deleteDesignation != null)
                {
                    context.Designations.Remove(deleteDesignation);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Qualifiaction
        public List<Qualification> GetQualificationList()
        {
            return context.Qualifications.ToList();
        }

        public Qualification GetQualificationByName(string qualificationName)
        {
            return context.Qualifications.FirstOrDefault(x => x.QualificationName == qualificationName);
        }

        public Qualification GetQualificationById(int id)
        {
            return context.Qualifications.FirstOrDefault(x => x.QualificationId == id);
        }

        public Qualification AddUpdateQualification(Qualification qualification)
        {
            if (default(int) == qualification.QualificationId)
            {
                context.Qualifications.Add(qualification);
            }
            else
            {
                context.Entry(qualification).State = EntityState.Modified;
            }
            context.SaveChanges();
            return qualification;
        }

        public bool DeleteQualification(int id)
        {
            var deleteQualification = context.Qualifications.FirstOrDefault(x => x.QualificationId == id);
            try
            {
                if (deleteQualification != null)
                {
                    context.Qualifications.Remove(deleteQualification);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Methods for leave types
        public List<LeaveType> GetLeaveTypeList()
        {
            return context.LeaveTypes.ToList();
        }

        public LeaveType GetLeaveTypeByName(string leaveTypeName)
        {
            return context.LeaveTypes.FirstOrDefault(x => x.LeaveTypeName == leaveTypeName);
        }

        public LeaveType AddUpdateLeaveType(LeaveType leaveType)
        {
            if (default(int) == leaveType.LeaveTypeId)
            {
                context.LeaveTypes.Add(leaveType);
            }
            else
            {
                context.Entry(leaveType).State = EntityState.Modified;
            }
            context.SaveChanges();
            return leaveType;
        }

        public LeaveType GetLeaveTypeById(int id)
        {
            return context.LeaveTypes.FirstOrDefault(x => x.LeaveTypeId == id);
        }

        public bool DeleteLeaveType(int id)
        {
            var deletedLeaveType = context.LeaveTypes.FirstOrDefault(x => x.LeaveTypeId == id);
            try
            {
                if (deletedLeaveType != null)
                {
                    context.LeaveTypes.Remove(deletedLeaveType);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Methods for holidays
        public List<Holiday> GetHolidayList()
        {
            return context.Holidays.ToList();
        }

        public Holiday GetHolidayByName(string holidayName)
        {
            return context.Holidays.FirstOrDefault(x => x.HolidayName == holidayName);
        }

        public Holiday AddUpdateHoliday(Holiday holiday)
        {
            if (default(int) == holiday.HolidayId)
            {
                context.Holidays.Add(holiday);
            }
            else
            {
                context.Entry(holiday).State = EntityState.Modified;
            }
            context.SaveChanges();
            return holiday;
        }

        public Holiday GetHolidayById(int id)
        {
            return context.Holidays.FirstOrDefault(x => x.HolidayId == id);
        }

        public bool DeleteHoliday(int id)
        {
            var deletedHoliday = context.Holidays.FirstOrDefault(x => x.HolidayId == id);
            try
            {
                if (deletedHoliday != null)
                {
                    context.Holidays.Remove(deletedHoliday);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
