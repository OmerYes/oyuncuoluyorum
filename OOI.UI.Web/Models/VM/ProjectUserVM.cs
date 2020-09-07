using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class ProjectUserVM : BaseVM
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string MainPhoto { get; set; }
        public int ProjectApplyCategoryID { get; set; }
    }
}