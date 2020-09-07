using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class AdvertDetailVM
    {
        public string CategoryName { get; set; }
        public string  MainPhoto { get; set; }
        public int AdvertCategoryID { get; set; }
        public string AdvertPhone { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public List<string> Photos { get; set; }

        public List<AdvertPhotosVM> AdvertPhotos { get; set; }
    }
}