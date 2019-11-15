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
    }
}
