using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Models.VM
{
    public class WebUserListVM : BaseVM
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Age { get; set; }
        public string ProfilePic  { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public int? CityID { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public int? Yas { get; set; }

        public IEnumerable<SelectListItem> drpCities { get; set; }
    }
}