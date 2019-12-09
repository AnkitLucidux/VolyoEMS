using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EMS.Entities;
using EMS.Web.Data;
using EMS.Web.Repositories;
using EMS.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EMS.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly AccountRepository accountRepository;

        protected User LoginUser;

        public BaseController(IHttpContextAccessor httpContextAccessor, AccountRepository accountRepository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.accountRepository = accountRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var aspUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            LoginUser = accountRepository.GetUserByAspId(Guid.Parse(aspUserId));
        }
    }
}