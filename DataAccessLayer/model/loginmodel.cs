using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.model
{
    class loginmodel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PassWord { get; set; }

    }
}
