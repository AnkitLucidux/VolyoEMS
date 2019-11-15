using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Entities;
using EMS.Web.Repositories;
using EMS.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMS.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        public RoleManager<IdentityRole> roleManager { get; }
        public UserManager<IdentityUser> userManager { get; }
        public AccountViewModelRepository accountViewModelRepository { get; }

        public UserController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, AccountViewModelRepository accountViewModelRepository)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.accountViewModelRepository = accountViewModelRepository;
        }

        // GET: User
        public async Task<ActionResult> Index()
        {
            List<UserViewModel> userList = new List<UserViewModel>();
            var aspUsers = userManager.Users;
            var users = accountViewModelRepository.GetAllUsers();

            foreach (var user in users)
            {
                var aspUser = await userManager.FindByIdAsync(user.AspUserId.ToString());
                var userRoleName = "Dummy";

                UserViewModel model = new UserViewModel();

                model.UserId = user.UserId;
                model.AspUserId = user.AspUserId;
                model.UserName = aspUser.UserName;
                model.Email = aspUser.Email;
                model.FullName = user.MiddileName != null ? user.FirstName + " " + user.MiddileName + " " + user.LastName : user.FirstName + " " + user.LastName;
                model.RoleName = userRoleName;
                model.IsActive = user.IsActive;
                model.IsDeleted = user.IsDeleted;
                userList.Add(model);
            }
            return View(userList);
        }

        //// GET: User/Details/5
        //public ActionResult Details(Guid id)
        //{
        //    UserViewModel model = new UserViewModel();
        //    var user = accountViewModelRepository.GetUserById(id);

        //    model.UserId = user.UserId;
        //    model.AspUserId = user.AspUserId;
        //    model.UserName = "Dummy";
        //    model.Email = user.Email;
        //    model.Password = "Dummy";
        //    model.ConfirmPassword = "Dummy";
        //    model.FirstName = user.FirstName;
        //    model.MiddileName = user.MiddileName;
        //    model.LastName = user.LastName;
        //    model.PhoneNumber = user.PhoneNumber;
        //    model.MobileNumber = user.MobileNumber;
        //    model.EmailConfirmed = user.EmailConfirmed;
        //    model.LastLogin = user.LastLogin;
        //    model.RoleId = "Dummy";
        //    model.RoleName = "Dummy";
        //    return View(model);
        //}

        // GET: User/Create
        public ActionResult Create()
        {
            UserViewModel model = new UserViewModel();
            model.Roles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();
            return View(model);
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserViewModel model)
        {
            model.Roles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();

            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var _user = await userManager.FindByEmailAsync(user.Email);
                if (_user == null)
                {
                    IdentityResult createUser = await userManager.CreateAsync(user, model.Password);
                    if (createUser.Succeeded)
                    {
                        IdentityRole role = await roleManager.FindByIdAsync(model.RoleId);
                        if (role != null)
                        {
                            //here we tie the new user to the role
                            await userManager.AddToRoleAsync(user, role.Name);

                            User addUser = new User();
                            addUser.AspUserId = new Guid(user.Id);
                            addUser.FirstName = model.FirstName;
                            addUser.MiddileName = model.MiddileName;
                            addUser.LastName = model.LastName;
                            addUser.Email = model.Email;
                            addUser.PhoneNumber = model.PhoneNumber;
                            addUser.MobileNumber = model.MobileNumber;

                            addUser.CreatedBy = 0; // There must be login user id

                            var result = accountViewModelRepository.AddUpdateUser(addUser);
                            if (result != null)
                            {
                                TempData["ErrorMessage"] = "User created successfully";
                            }
                            else
                            {
                                TempData["ErrorMessage"] = "Something went wrong while registering user!";
                            }
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Selected role not found!";
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Something went wrong while registering user!";
                    }
                }
            }
            return View(model);
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            UserViewModel model = new UserViewModel();
            var user = accountViewModelRepository.GetUserById(new Guid(id));
            var aspUser = await userManager.FindByIdAsync(user.AspUserId.ToString());

            model.UserId = user.UserId;
            model.AspUserId = user.AspUserId;
            model.UserName = aspUser.UserName;
            model.Email = aspUser.Email;
            model.FirstName = user.FirstName;
            model.MiddileName = user.MiddileName;
            model.LastName = user.LastName;
            model.PhoneNumber = user.PhoneNumber;
            model.MobileNumber = user.MobileNumber;
            model.CreatedDate = user.CreatedDate;
            model.ModifiedDate = user.ModifiedDate;
            model.CreatedBy = user.CreatedBy;
            model.ModifiedBy = user.ModifiedBy;
            model.LastLogin = user.LastLogin;
            model.RoleId = "Dummy";
            model.RoleName = "Dummy";
            model.Roles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();
            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserViewModel model)
        {
            model.Roles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();
            if (ModelState.IsValid)
            {
                var user = accountViewModelRepository.GetUserById(model.UserId);
                //var aspUser = await userManager.FindByIdAsync(user.AspUserId.ToString());

                //aspUser.Email = model.Email;
                //aspUser.UserName = model.UserName;
                //TO Do Tasks:
                //update password
                //update role

                //IdentityResult updatedAspUser = await userManager.UpdateAsync(aspUser);

                if (user != null)
                {
                    user.UserId = model.UserId;
                    user.AspUserId = model.AspUserId;
                    user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.MiddileName = model.MiddileName;
                    user.LastName = model.LastName;
                    user.PhoneNumber = model.PhoneNumber;
                    user.MobileNumber = model.MobileNumber;
                    user.EmailConfirmed = model.EmailConfirmed;

                    var result = accountViewModelRepository.AddUpdateUser(user);
                    if (result != null)
                    {
                        TempData["SuccessMessage"] = "User updated successfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Something went wrong while updating user!";
                    }
                }
            }
            return View(model);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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