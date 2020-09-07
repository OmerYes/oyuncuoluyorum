using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Models.VM
{
    public class CheckOutGetVM : BaseVM
    {
        public string FullName { get; set; }
        public string EMail { get; set; }
        public List<SelectListItem> drpCities { get; set; }
        public int Credits { get; set; }
        public double TotalPrice{ get; set; }
        public string OrderType { get; set; }
    }
}