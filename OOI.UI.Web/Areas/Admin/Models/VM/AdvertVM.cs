using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Areas.Admin.Models.VM
{
    public class AdvertVM:BaseVM
    {
        public string MainPhoto { get; set; }
        public int AdvertCategoryID { get; set; }
        public string AdvertPhone { get; set; }
        public IEnumerable<SelectListItem> drpAdvertCategories { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public string StartDateString { get; set; }
        public string EndDateString { get; set; }
    }
}