using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class pservice : dataservice
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}