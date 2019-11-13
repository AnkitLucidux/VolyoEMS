using EMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Services.IService
{
    public interface IUserService
    {
        User AddUpdateUser(User user);
    }
}
