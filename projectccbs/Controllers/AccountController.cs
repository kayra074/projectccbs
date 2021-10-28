using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projectccbs.Models;
using projectccbs.Models.ViewModels;
using projectccbs.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectccbs.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signinManager;
        RoleManager<IdentityRole> _rolemanager;

        public AccountController(ApplicationDbContext db,
             UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signinManager)
        {
            _db = db;
            _rolemanager = roleManager;
            _signinManager = signinManager;
            _userManager = userManager;

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _signinManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Appointment");
                }
                ModelState.AddModelError("", "Inloggen mislukt");
            }
            return View(model);
        }

        public async Task<IActionResult> Register()
        {
            // Creates all roles if role admin not exits
            if(!_rolemanager.RoleExistsAsync(Helper.Admin).GetAwaiter().GetResult())
            {
                await _rolemanager.CreateAsync(new IdentityRole(Helper.Admin));
                await _rolemanager.CreateAsync(new IdentityRole(Helper.Customer));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Voornaam = model.Voornaam,
                    Middelnaam = model.Middelnaam,
                    Achternaam = model.Achternaam
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Assign role to user and log the user in and redirect tot the homepage
                    await _userManager.AddToRoleAsync(user, model.RoleName);
                    await _signinManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                // Add all errors to the modelstate
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
