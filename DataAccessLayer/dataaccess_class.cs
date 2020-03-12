using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class dataaccess_class
    {
        public List<logindata>logindetails ()
        {
            dataaccess_class dac = new dataaccess_class();
            var data = from i in data.logins select i;
            List<logindata> log = new List<logindata>();
            return log;
        }
    }
    public class logindata
    {
        public int UserName;
        public int PassWord;
    }
}
