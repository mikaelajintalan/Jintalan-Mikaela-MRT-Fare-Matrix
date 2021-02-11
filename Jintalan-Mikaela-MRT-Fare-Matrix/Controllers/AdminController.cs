using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jintalan_Mikaela_MRT_Fare_Matrix.Models;

namespace Jintalan_Mikaela_MRT_Fare_Matrix.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private readonly MRTDbContext mrtDbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AdminController(MRTDbContext mrtDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.mrtDbContext = mrtDbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Clients()
        {

            return View(mrtDbContext.AppUsers.ToList());
        }
        
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await userManager.FindByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }
    }
}
