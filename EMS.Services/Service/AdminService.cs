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
    }
}
