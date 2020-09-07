using OOI.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Areas.Admin.Models.VM
{
    public class BlogCategoryVM : BaseVM
    {
        [Required(ErrorMessage ="Lütfen kategori adınız giriniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen kategori için açıklama metni giriniz.")]
        public string Description { get; set; }
        public string BlogCategoryName { get; internal set; }
    }
}