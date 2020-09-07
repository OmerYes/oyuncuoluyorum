using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class ProjectDetailVM : BaseVM
    {
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MainPhoto { get; set; }
        public string StartDateString { get; set; }
        public string EndDateString { get; set; }
        public string CategoryName { get; set; }
        public List<string> Photos{ get; set; }

        public bool ApplyStatus { get; set; }

        public List<ProjectPhotosVM> ProjectPhotos { get; set; }

        public List<ProjectUserVM> ProjectUsers { get; set; }
    }
}