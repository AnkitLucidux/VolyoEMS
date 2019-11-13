using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Entities.DBContext
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            InitializeDomainData(modelBuilder);
        }


        public static void InitializeDomainData(ModelBuilder modelBuilder)
        {
            //UserRoles(modelBuilder);
        }

        //private static void UserRoles(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<EmployeeDetail>().HasData(
        //        new EmployeeDetail
        //        {
        //            EmployeeId = 1,
        //            FirstName = "Ankit",
        //            MiddileName = "",
        //            LastName = "Chaturvedi"
        //        }
        //        );
        //}

    }
}
