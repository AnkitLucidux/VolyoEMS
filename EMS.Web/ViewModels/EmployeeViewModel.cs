using EMS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.ViewModels
{
    public class EmployeeViewModel : EntityBaseClass
    {
        [Key]
        public int Id { get; set; }

        public Qualification Qualification { get; set; }

        public Department Department { get; set; }

        public Designation Designation { get; set; }

        public List<Qualification> QualificationList { get; set; }

        public List<Department> DepartmentList { get; set; }

        public List<Designation> DesignationList { get; set; }

        public List<Employee> EmployeeList { get; set; }

        public Employee Employee { get; set; }
    }
}
