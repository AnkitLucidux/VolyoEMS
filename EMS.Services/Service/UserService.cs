using EMS.Entities;
using EMS.Entities.DBContext;
using EMS.Services.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Services.Service
{
    public class UserService : IUserService
    {
        private readonly EMSDbContext context;

        public UserService(EMSDbContext emsDbContext)
        {
            context = emsDbContext;
        }

        public User AddUpdateUser(User user)
        {
            if (default(Guid) == user.UserId)
            {
                user.UserId = Guid.NewGuid();
                context.Users.Add(user);
            }
            else
            {
                user.ModifiedDate = DateTime.Now;
                context.Entry(user).State = EntityState.Modified;
            }

            context.SaveChanges();
            return user;
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(Guid id)
        {
            return context.Users.Where(m => m.UserId == id).FirstOrDefault();
        }
    }
}
