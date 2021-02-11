using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Jintalan_Mikaela_MRT_Fare_Matrix.Models;

namespace Jintalan_Mikaela_MRT_Fare_Matrix.Controllers
{
    public class AuthController : Controller
    {
        private readonly MRTDbContext authDbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, MRTDbContext authDbContext)
        {
            this.authDbContext = authDbContext;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string passWord)
        {
            var user = await userManager.FindByNameAsync(userName); 

            if (user != null)
            {
                
               
                var signInResult = await signInManager.PasswordSignInAsync(user.UserName, passWord, false, false);

                if (signInResult.Succeeded)
                {
                    if(user.Access == "Client")
                    {
                        return RedirectToAction("Index", "Client", new { area = "" });
                    }
                }
            }

            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string userName, string passWord, string firstName, string lastName)
        {
            var user = new AppUser
            {
                FirstName = firstName,
                Access = "Client",
                LastName = lastName,
                UserName = userName,
            };

            var result = await userManager.CreateAsync(user, passWord);
            
            if (result.Succeeded)
            {
                user = await userManager.FindByNameAsync(user.UserName);

                await authDbContext.AddRangeAsync();
                await authDbContext.SaveChangesAsync();

                var ClientProfile = new ClientProfile
                {
                    AppUserID = user.Id,
                };

                await  authDbContext.AddAsync(ClientProfile);
                await authDbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Client", new { area = "" } );
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
