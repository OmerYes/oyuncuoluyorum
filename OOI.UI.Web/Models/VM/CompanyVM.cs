using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class CompanyVM : BaseVM
    {
        public HttpPostedFileBase Mainphoto{ get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LogoPath { get; set; }
    }
}