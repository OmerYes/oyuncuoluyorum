using OOI.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Areas.Admin.Models.VM
{
    public class BlogVM : BaseVM
    {
        [Required(ErrorMessage="Lütfen başlık giriniz.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen açıklama giriniz.")]
        public string Description { get; set; }
        public List<SelectListItem> drpBlogCategoryList { get; set; }
        [Required(ErrorMessage = "Lütfen kategori belirtiniz.")]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

    }
}