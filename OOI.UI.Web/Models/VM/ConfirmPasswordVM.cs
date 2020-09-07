using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class ConfirmPasswordVM : BaseVM
    {
        [Required]
        public string Code { get; set; }
    }
}