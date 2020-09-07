using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class ProjectApplyDetailVM : BaseVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CoverPhoto { get; set; }
        public string StartDateString { get; set; }
        public string EndDateString { get; set; }
        public string CategoryName { get; set; }
        public string ApplyDateString { get; set; }
        public bool? IsAdded { get; set; }
        public int? CompanyID { get; set; }
        public int? ProjectID { get; set; }
    }
}