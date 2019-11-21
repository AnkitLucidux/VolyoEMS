using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IdentityUser LoginUser;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext context;

        public BaseController(UserManager<IdentityUser> userManager,ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
            GetLoginUser();
        }

        public async void GetLoginUser()
        {
            var loginUserId = userManager.GetUserId(HttpContext.User);
            LoginUser = await userManager.FindByIdAsync(loginUserId);
        }
    }
}