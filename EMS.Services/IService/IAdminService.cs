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
    }
}
