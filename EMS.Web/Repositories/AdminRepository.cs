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

    }
}
