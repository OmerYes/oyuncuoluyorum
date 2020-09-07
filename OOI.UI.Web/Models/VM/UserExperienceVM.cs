using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class UserExperienceVM:BaseVM
    {
        public DateTime CreatedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public string CreatedDateString { get; set; }
        //public string FinishedDateString { get; set; }

        public string ProjectDate { get; set; }
        public int WebUserID { get; set; }
    }
}