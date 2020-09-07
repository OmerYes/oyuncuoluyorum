using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Areas.Admin.Models.VM
{
    public class ProjectCategoryVM : BaseVM
    {
        [Required(ErrorMessage ="Bu alan boş bırakılamaz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string Description { get; set; }

    }
}