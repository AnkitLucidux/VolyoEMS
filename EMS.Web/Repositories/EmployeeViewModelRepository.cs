﻿using EMS.Entities;
using EMS.Entities.DBContext;
using EMS.Services.IService;
using EMS.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Repositories
{
    public class EmployeeViewModelRepository
    {
        public IEmployeeService employeeService;

        public EmployeeViewModelRepository(EMSDbContext eMSDbContext)
        {
            employeeService = new EmployeeService(eMSDbContext);
        }

        public Employee AddUpdateEmployee(Employee user)
        {
            return employeeService.AddUpdateEmployee(user);
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeService.GetAllEmployees();
        }

        public Employee GetEmployeeById(Guid id)
        {
            return employeeService.GetEmployeeById(id);
        }

        public bool DeleteEmployeeById(Guid id)
        {
            return employeeService.DeleteEmployeeById(id);
        }
    }
}
