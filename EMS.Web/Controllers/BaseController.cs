using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EMS.Web.Data;
using EMS.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EMS.Web.Controllers
{
    public class BaseController : Controller
    {
        protected UserViewModel LoginUser = new UserViewModel();

        private readonly IHttpContextAccessor httpContextAccessor;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            //this.userManager = userManager;
            //this.context = context;
            //GetLoginUser();
            this.httpContextAccessor = httpContextAccessor;

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var user = httpContextAccessor.HttpContext.User;
            var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userName = user.FindFirst(ClaimTypes.Name).Value;
            var userRole = user.FindFirst(ClaimTypes.Role).Value;

            LoginUser.User.AspUserId = Guid.Parse(userId);
            LoginUser.User.Email = userName;
            LoginUser.RoleName = userRole;
        }

        //public string LoginUser()
        //{
        //    return "";
        //}
        //public async void GetLoginUser()
        //{
        //    var loginUserId = userManager.GetUserId(HttpContext.User);
        //    LoginUser = await userManager.FindByIdAsync(loginUserId);
        //}
    }
}