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
    [Authorize(Roles = "Admin")]
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
            List<RoleViewModel> roleList = new List<RoleViewModel>();
            var roles = roleManager.Roles;
            foreach (var role in roles)
            {
                RoleViewModel model = new RoleViewModel();
                model.RoleId = role.Id;
                model.RoleName = role.Name;
                roleList.Add(model);
            }

            return View(roleList);
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
            try
            {
                if (ModelState.IsValid)
                {
                    var role = await roleManager.FindByNameAsync(model.RoleName);

                    if (role != null && model.RoleId != role.Id)
                    {
                        TempData["ErrorMessage"] = "Role is already exists";
                        return View();
                    }

                    if (role == null)
                    {
                        role = await roleManager.FindByIdAsync(model.RoleId);
                    }

                    role.Id = model.RoleId;
                    role.Name = model.RoleName;

                    IdentityResult result = await roleManager.UpdateAsync(role);
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
            }
            catch
            {
                return View();
            }
        }

        // POST: Role/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    TempData["ErrorMessage"] = "Somthing went wrong. Please try again!";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "No role found";
            }

            return RedirectToAction("Index");
        }
    }
}