using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jintalan_Mikaela_MRT_Fare_Matrix.Models
{
    public class ClientProfile    {
        [Key]
        public int ID { get; set; }
        public string AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
