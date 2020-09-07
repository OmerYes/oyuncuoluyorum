using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class ForgetPasswordVM : BaseVM
    {
        [Required(ErrorMessage ="Lütfen telefon numarasını giriniz")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen email adresiniz giriniz")]
        [EmailAddress]
        public string EMail { get; set; }
    }
}