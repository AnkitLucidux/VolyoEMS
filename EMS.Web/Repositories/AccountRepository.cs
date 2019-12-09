using EMS.Entities;
using EMS.Entities.DBContext;
using EMS.Services.IService;
using EMS.Services.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Web.Repositories
{
    public class AccountRepository
    {
        public IUserService userService;

        public AccountRepository(EMSDbContext eMSDbContext)
        {
            userService = new UserService(eMSDbContext);
        }

        public User AddUpdateUser(User user)
        {
            return userService.AddUpdateUser(user);
        }

        public List<User> GetAllActiveUsers()
        {
            return userService.GetAllActiveUsers();
        }

        public List<User> GetAllUsers()
        {
            return userService.GetAllUsers();
        }

        public User GetUserById(Guid id)
        {
            return userService.GetUserById(id);
        }

        public User GetUserByAspId(Guid aspId)
        {
            return userService.GetUserByAspId(aspId);
        }

        public bool DeleteUserById(Guid id)
        {
            return userService.DeleteUserById(id);
        }
    }
}
