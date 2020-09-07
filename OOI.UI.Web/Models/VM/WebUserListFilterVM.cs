using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class WebUserListFilterVM
    {
        public string ajans { get; set; }
        public string egitim { get; set; }
        public string oyuncu_tur { get; set; }
        public string cinsiyet { get; set; }
        public int sehir { get; set; }
        public string dil { get; set; }
        public string yas { get; set; }
        public string kilo { get; set; }
        public string boy { get; set; }
    }
}