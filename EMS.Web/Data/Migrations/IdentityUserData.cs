using EMS.Entities;
using EMS.Entities.DBContext;
using EMS.Web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Data.Migrations
{
    public class IdentityUserData
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            try
            {
                //adding custom roles
                var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
                string roleName = "Admin";

                //creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    IdentityResult roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }

                //creating a super user who could maintain the web app
                var adminUser = new IdentityUser
                {
                    UserName = "admin@lucidux.com",
                    Email = "admin@lucidux.com"
                };

                string UserPassword = "Admin@123";
                var _user = await UserManager.FindByEmailAsync(adminUser.Email);
                if (_user == null)
                {
                    var createAdminUser = await UserManager.CreateAsync(adminUser, UserPassword);
                    if (createAdminUser.Succeeded)
                    {
                        //here we tie the new user to the "Admin" role
                        await UserManager.AddToRoleAsync(adminUser, "Admin");

                        var _emsContext = serviceProvider.GetRequiredService<EMSDbContext>();
                        AccountRepository accountRepository = new AccountRepository(_emsContext);

                        User addUser = new User();
                        addUser.AspUserId = new Guid(adminUser.Id);
                        addUser.FirstName = "Volyo";
                        addUser.LastName = "Admin";
                        addUser.Email = "admin@lucidux.com";
                        
                        accountRepository.AddUpdateUser(addUser);
                    }
                }
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
        }
    }
}
