using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Jintalan_Mikaela_MRT_Fare_Matrix.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string Access { get; set; }
        public string LastName { get; set; }
    }
}
