using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DataAccessLayer.model
{
   public class newpatient
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PassWord { get; set; }

    }
}
