using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class FirmProjectVM
    {
        public ProjectVM Project { get; set; }

        public List<ProjectUserVM>  ProjectUsers { get; set; }

        public List<string> ProjectPhotos { get; set; }
    }
}