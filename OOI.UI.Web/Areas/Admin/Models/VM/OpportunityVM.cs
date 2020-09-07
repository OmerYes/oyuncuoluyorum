using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Areas.Admin.Models.VM
{
    public class OpportunityVM:BaseVM
    {
        [Required(ErrorMessage = "Lütfen fırsat adını giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen fırsat açıklaması giriniz")]
        public string Description { get; set; }
        public string MainPhoto { get; set; }
        public string StartDateString { get; set; }
    }
}