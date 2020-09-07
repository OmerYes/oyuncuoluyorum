using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Areas.Admin.Models.VM
{
    public class ProjectApplyUserVM : BaseVM
    {
        public int ProjectID { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string UserLastName { get; set; }
    }
}