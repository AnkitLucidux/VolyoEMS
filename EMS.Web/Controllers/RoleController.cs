using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Web.Data;
using EMS.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Web.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        // GET: Role
        public ActionResult Index()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var roleExist = await roleManager.RoleExistsAsync(model.RoleName);
                    if (!roleExist)
                    {
                        IdentityResult roleResult = await roleManager.CreateAsync(new IdentityRole(model.RoleName));
                        if (roleResult.Succeeded)
                        {
                            TempData["ErrorMessage"] = "Role created successfully";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Something went wrong!";

                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Role is already exists";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        public ActionResult Edit(string id)
        {
            var role = roleManager.FindByIdAsync(id);
            if (role == null)
            {
                TempData["ErrorMessage"] = "No role found!";
                return View("Index");
            }
            RoleViewModel model = new RoleViewModel();
            model.RoleId = role.Result.Id;
            model.RoleName = role.Result.Name;

            return View(model);
        }

        // POST: Role/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RoleViewModel model)
        {
            //try
            //{
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByNameAsync(model.RoleName); //HR //Admin

                if (role != null && model.RoleId != role.Id)
                {
                    TempData["ErrorMessage"] = "Role is already exists";
                }

                IdentityRole identityRole = new IdentityRole
                {
                    Id = model.RoleId,
                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.UpdateAsync(identityRole);
                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Role updated successfully";

                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong!";
                }
            }
            return View();
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Role/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Role deleted successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong!";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "No role found";
            }
            //ModelState.AddModelError("", "No role found");
            return RedirectToAction("Index");
        }
    }
}