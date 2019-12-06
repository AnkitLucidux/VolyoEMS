using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EMS.Entities;
using EMS.Web.Repositories;
using EMS.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly HostingEnvironment hostingEnvironment;

        public RoleManager<IdentityRole> roleManager { get; }
        public UserManager<IdentityUser> userManager { get; }
        public AccountRepository accountRepository { get; }
        string directoryPath = string.Empty;

        public UserController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, AccountRepository accountRepository, HostingEnvironment hostingEnvironment)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.accountRepository = accountRepository;
            this.hostingEnvironment = hostingEnvironment;
            directoryPath = Path.Combine(hostingEnvironment.WebRootPath + "\\Images\\UserImage");
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            List<UserViewModel> userList = new List<UserViewModel>();
            //var aspUsers = userManager.Users;
            var users = accountRepository.GetAllUsers();

            foreach (var user in users)
            {
                var aspUser = await userManager.FindByIdAsync(user.AspUserId.ToString());
                var userRoleName = await userManager.GetRolesAsync(aspUser);
                var userRole = await roleManager.FindByNameAsync(userRoleName[0]);

                UserViewModel model = new UserViewModel();
                model.User = new User();
                model.UserName = aspUser.UserName;
                model.FullName = user.MiddileName != null ? user.FirstName + " " + user.MiddileName + " " + user.LastName : user.FirstName + " " + user.LastName;
                model.RoleName = userRole.Name;
                model.User = user;
                userList.Add(model);
            }
            return View(userList);
        }

        //// GET: User/Details/5
        //public ActionResult Details(Guid id)
        //{
        //    UserViewModel model = new UserViewModel();
        //    var user = accountRepository.GetUserById(id);

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
        public IActionResult Create()
        {
            UserViewModel model = new UserViewModel();
            model.User = new User();
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
        public async Task<IActionResult> Create(UserViewModel model)
        {
            model.Roles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();

            string uniqueFileName = null;
            IdentityUser user = new IdentityUser();
            try
            {
                if (ModelState.IsValid)
                {
                    user = new IdentityUser
                    {
                        UserName = model.User.Email,
                        Email = model.User.Email
                    };

                    IdentityUser identityUser = await userManager.FindByEmailAsync(user.Email);
                    if (identityUser == null)
                    {
                        IdentityResult createUser = await userManager.CreateAsync(user, model.Password);
                        if (createUser.Succeeded)
                        {
                            IdentityRole role = await roleManager.FindByIdAsync(model.RoleId.ToString());
                            if (role != null)
                            {
                                //here we tie the new user to the role
                                await userManager.AddToRoleAsync(user, role.Name);

                                User addUser = new User();
                                addUser = model.User;
                                addUser.AspUserId = new Guid(user.Id);

                                //addUser.CreatedBy = 0; // There must be login user id

                                if (model.ProfileImage != null)
                                {
                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);
                                    }

                                    uniqueFileName = addUser.AspUserId + "$$" + model.ProfileImage.FileName;
                                    string filePath = Path.Combine(directoryPath, uniqueFileName);
                                    model.ProfileImage.CopyTo(new FileStream(filePath, FileMode.Create));
                                    addUser.ImagePath = uniqueFileName;
                                }

                                //throw new System.ArgumentException("Parameter cannot be null", "original");
                                var result = accountRepository.AddUpdateUser(addUser);
                                if (result != null)
                                {
                                    TempData["SuccessMessage"] = "User created successfully";
                                    return RedirectToAction("Index");
                                }
                            }
                            else
                            {
                                TempData["ErrorMessage"] = "Selected role not found!";
                                var aspUser = await userManager.FindByIdAsync(user.Id);
                                await userManager.DeleteAsync(aspUser);
                            }
                        }
                        else
                        {
                            foreach (var error in createUser.Errors)
                            {
                                TempData["ErrorMessage"] = error.Description;
                            }
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = $"User {model.User.Email} is already taken.";
                    }
                }
            }
            catch (Exception ex)
            {
                //Roll back created user if any error occours.
                var aspUser = await userManager.FindByIdAsync(user.Id);
                var userRoleName = await userManager.GetRolesAsync(aspUser);

                await userManager.RemoveFromRoleAsync(aspUser, userRoleName[0]);
                IdentityResult deletedAspUser = await userManager.DeleteAsync(aspUser);

                if (deletedAspUser.Succeeded)
                {
                    //Deleting image from server
                    string deletedFilePath = Path.Combine(hostingEnvironment.WebRootPath + "\\Images\\UserImage\\" + uniqueFileName);
                    if (System.IO.File.Exists(deletedFilePath))
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        System.IO.File.Delete(deletedFilePath);
                    }
                }
                TempData["ErrorMessage"] = "Something went wrong while registering user!";
            }
            return View(model);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            UserViewModel model = new UserViewModel();
            model.User = new User();

            var user = accountRepository.GetUserById(new Guid(id));
            var aspUser = await userManager.FindByIdAsync(user.AspUserId.ToString());
            var userRoleName = await userManager.GetRolesAsync(aspUser);
            var userRole = await roleManager.FindByNameAsync(userRoleName[0]);

            model.User = user;
            model.UserName = aspUser.UserName;
            model.User.Email = aspUser.Email;
            model.RoleId = Guid.Parse(userRole.Id);
            model.RoleName = userRole.Name;
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
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            //TO Do Tasks:
            //update password
            ModelState.Remove("Password");
            ModelState.Remove("ConfirmPassword");

            if (ModelState.IsValid)
            {
                var user = accountRepository.GetUserById(model.User.UserId);
                var aspUser = await userManager.FindByIdAsync(user.AspUserId.ToString());
                var userRoleName = await userManager.GetRolesAsync(aspUser);
                var userRole = await roleManager.FindByNameAsync(userRoleName[0]);

                aspUser.Email = model.User.Email;
                aspUser.UserName = model.User.Email;

                IdentityResult updatedAspUser = await userManager.UpdateAsync(aspUser);
                if (updatedAspUser.Succeeded && user != null)
                {
                    IdentityRole role = await roleManager.FindByIdAsync(model.RoleId.ToString());
                    if (role != null)
                    {
                        await userManager.RemoveFromRoleAsync(aspUser, userRole.Name);
                        await userManager.AddToRoleAsync(aspUser, role.Name);

                        //user = model.User;
                        user.UserId = model.User.UserId;
                        user.AspUserId = model.User.AspUserId;
                        user.Email = model.User.Email;
                        user.FirstName = model.User.FirstName;
                        user.MiddileName = model.User.MiddileName;
                        user.LastName = model.User.LastName;
                        user.PhoneNumber = model.User.PhoneNumber;
                        user.MobileNumber = model.User.MobileNumber;

                        string uniqueFileName = null;
                        if (model.ProfileImage != null)
                        {
                            string deletedFilePath = Path.Combine(hostingEnvironment.WebRootPath + "\\Images\\UserImage\\" + user.ImagePath);
                            if (System.IO.File.Exists(deletedFilePath))
                            {
                                System.GC.Collect();
                                System.GC.WaitForPendingFinalizers();
                                System.IO.File.Delete(deletedFilePath);
                            }

                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }
                            uniqueFileName = user.AspUserId + "$$" + model.ProfileImage.FileName;
                            string filePath = Path.Combine(directoryPath, uniqueFileName);
                            model.ProfileImage.CopyTo(new FileStream(filePath, FileMode.Create));
                            user.ImagePath = uniqueFileName;
                        }
                        else
                        {
                            user.ImagePath = null;
                        }

                        var result = accountRepository.AddUpdateUser(user);
                        if (result != null)
                        {
                            TempData["SuccessMessage"] = "User updated successfully";
                            return RedirectToAction("Edit", new { id = user.UserId });
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Something went wrong while updating user!";
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Selected role not found!";
                    }
                }
                else
                {
                    string errorMessage = string.Empty;
                    foreach (var error in updatedAspUser.Errors)
                    {
                        errorMessage += error.Description;
                    }
                    TempData["ErrorMessage"] = errorMessage;
                }
            }

            model.Roles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();
            return View(model);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Deactivate(Guid id)
        {
            var user = accountRepository.GetUserById(id);
            var aspUser = await userManager.FindByIdAsync(user.AspUserId.ToString());
            var userRoleName = await userManager.GetRolesAsync(aspUser);

            if (userRoleName[0] != "Admin")
            {
                if (user != null)
                {
                    user.IsActive = false;
                    user.IsDeleted = true;

                    var result = accountRepository.AddUpdateUser(user);
                    if (result != null)
                    {
                        TempData["SuccessMessage"] = "Employee deactivated successfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Something went wrong while deactivating employee!";
                    }
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Admin can not be deactivated";
            }

            return RedirectToAction("Index");
        }

        // GET: Employee/Edit/5
        public IActionResult Activate(Guid id)
        {
            var user = accountRepository.GetUserById(id);
            if (user != null)
            {
                user.IsActive = true;
                user.IsDeleted = false;

                var result = accountRepository.AddUpdateUser(user);
                if (result != null)
                {
                    TempData["SuccessMessage"] = "Employee activated successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong while deactivating employee!";
                }
            }

            return RedirectToAction("Index");
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var user = accountRepository.GetUserById(id);
                var aspUser = await userManager.FindByIdAsync(user.AspUserId.ToString());
                var userRoleName = await userManager.GetRolesAsync(aspUser);

                if (userRoleName[0] != "Admin")
                {
                    await userManager.RemoveFromRoleAsync(aspUser, userRoleName[0]);
                    IdentityResult deletedAspUser = await userManager.DeleteAsync(aspUser);

                    if (deletedAspUser.Succeeded)
                    {
                        var result = accountRepository.DeleteUserById(user.UserId);
                        if (result)
                        {
                            TempData["SuccessMessage"] = "Employee deleted Successfully";
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Somthing went wrong. Please try again!";
                        }
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Admin can not be deleted.";
                }
            }
            catch
            {
                TempData["ErrorMessage"] = "Somthing went wrong. Please try again!";
            }
            return RedirectToAction("Index");
        }
    }
}