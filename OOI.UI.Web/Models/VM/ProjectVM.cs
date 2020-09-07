using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Models.VM
{
    public class ProjectVM : BaseVM
    {
        public string MainPhoto { get; set; }
        public string FirmName { get; set; }
        public int ProjectCategoryID { get; set; }
        public IEnumerable<SelectListItem> drpProjectCategories { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartDateString { get; set; }
        public string EndDateString { get; set; }
        public string CategoryName { get; set; }
        public int CompanyID { get; set; }

        public bool ApplyStatus { get; set; }
    }
}