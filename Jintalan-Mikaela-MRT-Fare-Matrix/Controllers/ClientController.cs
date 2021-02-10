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
    [Authorize(Roles = "Client")]
    public class ClientController : Controller
    {
        private readonly MRTDbContext mrtDbContext;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public ClientController(MRTDbContext mrtDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.mrtDbContext = mrtDbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Client = await userManager.FindByIdAsync(id);
            var ClientProfile = await mrtDbContext.clientProfile.FirstOrDefaultAsync(i => i.AppUserID == id);
            if (ClientProfile == null)
            {
                return NotFound();
            }
            ClientProfile.AppUser = Client;
            return View(ClientProfile);

        }
    }
}
