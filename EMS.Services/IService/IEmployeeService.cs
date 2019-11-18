using EMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Services.IService
{
    public interface IEmployeeService
    {
        Employee AddUpdateEmployee(Employee user);

        List<Employee> GetAllEmployees();

        Employee GetEmployeeById(Guid id);

        bool DeleteEmployeeById(Guid id);
    }
}
