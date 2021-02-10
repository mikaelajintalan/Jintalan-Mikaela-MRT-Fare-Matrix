using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Jintalan_Mikaela_MRT_Fare_Matrix.Models;

namespace Jintalan_Mikaela_MRT_Fare_Matrix.Models
{
    public class MRTDbContext : IdentityDbContext
    {
        public MRTDbContext( DbContextOptions<MRTDbContext> options) : base(options)
        {

        }
        
        public DbSet<AppUser> AppUsers { get; set; }
       
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string ADMIN_ID = "16446968-4cef-46d6-83c5-d3a00de4f250";
            //create user
            var appUser = new AppUser
            {
                Id = ADMIN_ID,
                Email = "jintalanmikaela@gmail.com",
                EmailConfirmed = true,
                FirstName = "Mika",
                UserName = "adminMika",
                Access = "Admin",
                NormalizedUserName = "ADMINMIKA",
                NormalizedEmail = "JINTALANMIKAELA@GMAIL.COM"
            };
            //set user password
            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "mikay23");
            //seed user
            builder.Entity<AppUser>().HasData(appUser);
        }
    }

}
