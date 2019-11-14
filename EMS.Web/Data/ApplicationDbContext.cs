using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EMS.Entities;
using EMS.Web.ViewModels;

namespace EMS.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EMS.Entities.Department> Department { get; set; }
        public DbSet<EMS.Web.ViewModels.RoleViewModel> RoleViewModel { get; set; }
        public DbSet<EMS.Web.ViewModels.UserViewModel> UserViewModel { get; set; }
    }
}
