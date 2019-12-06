using EMS.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.Web.ViewModels
{
    public class EmployeeViewModel
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

        public List<SelectListItem> ReportToList { get; set; }

        public Employee Employee { get; set; }

        [Display(Name = "Profile Image")]
        [DataType(DataType.Upload)]
        public IFormFile ProfileImage { get; set; }
    }
}
