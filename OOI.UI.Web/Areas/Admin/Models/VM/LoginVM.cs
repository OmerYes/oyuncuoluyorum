using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Areas.Admin.Models.VM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Lütfen e-mail adresinizi giriniz.")]
        [EmailAddress(ErrorMessage = "Lütfen e-mail adresinizi doğru girdiğinizden emin olunuz.")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen parolanızı giriniz.")]
        [StringLength(15)]
        public string Password { get; set; }
        public string ConfirmCode { get; set; }
    }
}