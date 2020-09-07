using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Areas.Admin.Models.VM
{
    public class CompanyVM : BaseVM
    {
        [Required(ErrorMessage ="Bu alan boş bırakılamaz.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string Phone { get; set; }

        public List<SelectListItem> drpBlogCategoryList { get; set; }
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }

        public List<SelectListItem> drpCompanyCategories{ get; set; }
    }
}