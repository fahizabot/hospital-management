using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.model
{
    public class appointment
    {
        [Required]
        [StringLength(5)]
        public string UserName { get; set; }
        [Required]
        public string pay { get; set; }
        [Required]
        public int Timings { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Slot { get; set; }
        [Required]
        public string Prescription { get; set; }

    }
}