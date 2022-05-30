using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        IAccountService accountService;
        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
      
        public IActionResult Index()
        {
            SignUpViewModel vm = new SignUpViewModel();
            List<IdentityRole> liRole = accountService.GetRoles();
            vm.liRoles = liRole;
            return View("CreateAccount", vm);
        }
       
        public async Task<IActionResult> CreateAccount(SignUpViewModel signUpViewModel)
        {
            SignUpViewModel vm = new SignUpViewModel();
            List<IdentityRole> liRole = accountService.GetRoles();
            vm.liRoles = liRole;
            var result = await accountService.CreateUser(signUpViewModel.signUpModel);

            return View("CreateAccount", vm);
        }

        public IActionResult SignIn()
        {
            return View("Login");
        }

        public async Task<IActionResult> SignOut()
        {
            await accountService.Logout();
            return View("Login");
        }



        public async Task<IActionResult> CheckPassword(SignInModel signInModel)
        {
            var result = await accountService.CheckPassword(signInModel);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Auther");
            }
            else
            {
                ViewData["errorMessage"] = "Invalid Username or Password";
                return View("Login");
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult NewRole()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveRole(RoleModel roleModel)
        {
            var result = await accountService.NewRole(roleModel);
            return View("NewRole");
        }

        public IActionResult AccessDenied1()
        {
            return View("AccessDenied");
        }
    }
}
