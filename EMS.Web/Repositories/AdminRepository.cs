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
        
    }
}
