using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMS.Web.Models;
using EMS.Entities;
using EMS.Web.Repositories;
using EMS.Entities.DBContext;

namespace EMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountViewModelRepository _accountViewModelRepository;
        public HomeController(AccountViewModelRepository accountViewModelRepository)
        {
            _accountViewModelRepository = accountViewModelRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
