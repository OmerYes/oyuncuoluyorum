using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class WebUserPhotosVM : BaseVM
    {
        public List<HttpPostedFileBase> file { get; set; }
        public string Path { get; set; }

        public int[] photoid { get; set; }
    }
}