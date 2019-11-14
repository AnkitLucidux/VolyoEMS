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
    public class EmployeeService : IEmployeeService
    {
        private readonly EMSDbContext context;

        public EmployeeService(EMSDbContext emsDbContext)
        {
            this.context = emsDbContext;
        }

        public Employee AddUpdateEmployee(Employee employee)
        {
            if (default(Guid) == employee.EmployeeId)
            {
                employee.EmployeeId = Guid.NewGuid();
                context.Employees.Add(employee);
            }
            else
            {
                employee.ModifiedDate = DateTime.Now;
                context.Entry(employee).State = EntityState.Modified;
            }

            context.SaveChanges();
            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            return context.Employees.ToList();
        }

        public Employee GetEmployeeById(Guid id)
        {
            return context.Employees.Where(m => m.EmployeeId == id).FirstOrDefault();
        }
    }
}
