using BookApp.WebUI.Areas.Admin.Models;
using BookApp.WebUI.Entitiy;
using BookApp.WebUI.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.WebUI.Areas.Admin.Controllers
{
    [Authorize/*(Roles ="Admin")*/]
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel role)
        {
            AppRole appRole = new();
            appRole.Name = role.Name;
            IdentityResult result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("List");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(role.Name);
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _roleManager.Roles.ToList();
            if (values != null)
            {
                return View(values);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return View("NotFound");
            }

            var model = new UpdateAppRoleViewModel()
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach (var user in _userManager.Users.ToList())
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAppRoleViewModel appRole)
        {
            AppRole role = await _roleManager.FindByIdAsync(appRole.Id);

            if (role != null)
            {
                role.Name = appRole.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("List", "Role");
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUsersInRole(string roleId)
        {
            ViewBag.RoleId = roleId;
            var role = await _roleManager.FindByIdAsync(roleId);

            var model = new List<UserRoleViewModel>();
            foreach (var user in _userManager.Users.ToList())
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Selected = await _userManager.IsInRoleAsync(user, role.Name)
                };


                model.Add(userRoleViewModel);
            }
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateUsersInRole(List<UserRoleViewModel> models, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            for (int i = 0; i < models.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(models[i].UserId);

                IdentityResult result = null;

                if (models[i].Selected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                     result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!models[i].Selected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
                if (result.Succeeded)
                {
                    if (i < (models.Count - 1))
                        continue;
                    else
                        return RedirectToAction("Update", new { Id = roleId });
                }
            }

            return RedirectToAction("Update", new { Id = roleId });
        }

    }
}
