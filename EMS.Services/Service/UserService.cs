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

        public List<User> GetAllActiveUsers()
        {
            return context.Users.Where(m => m.IsActive && !m.IsDeleted).ToList();
        }

        public User GetUserById(Guid id)
        {
            return context.Users.Where(m => m.UserId == id).FirstOrDefault();
        }

        public bool DeleteUserById(Guid id)
        {
            try
            {
                var result = context.Users.FirstOrDefault(m => m.UserId == id);
                if (result != null)
                {
                    context.Users.Remove(result);
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
