using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DataAccessLayer.model
{
    public class specialist
    {
        [Required]
        public int SpecialistId { get; set; }
        [Required]
        public string SpecialistName { get; set; }
    }
}
