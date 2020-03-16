using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.model
{
    public class appointment
    {
        public string UserName { get; set; }
        public string pay { get; set; }
        public int Timings { get; set; }
        public string Description { get; set; }
        public string Slot { get; set; }
        public string Prescription { get; set; }

    }
}
