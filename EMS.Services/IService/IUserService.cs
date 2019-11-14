using EMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Services.IService
{
    public interface IUserService
    {
        User AddUpdateUser(User user);

        List<User> GetAllUsers();

        User GetUserById(Guid id);
    }
}
