using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class OrderHistoryVM
    {
        public bool IsFirm { get; set; }
        public string FullName { get; set; }
        public int Credit { get; set; }
        public int PurchasedCredit { get; set; }
        public string Photo { get; set; }

    }
}