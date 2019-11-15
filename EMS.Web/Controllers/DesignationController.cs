using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    public class DesignationController : Controller
    {
        private readonly AdminRepository _adminRepository;
        public DesignationController(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        // GET: Designation
        public ActionResult Index()
        {
            return View();
        }

        // GET: Designation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Designation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Designation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Designation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Designation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Designation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Designation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}