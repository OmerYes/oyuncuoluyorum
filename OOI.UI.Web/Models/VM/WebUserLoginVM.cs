using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class WebUserLoginVM
    {
        [Required(ErrorMessage = "Lütfen e-mail adresinizi giriniz.")]
        [EmailAddress(ErrorMessage = "Lütfen e-mail adresinizi doğru girdiğinizden emin olunuz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen parolanızı giriniz.")]
        public string Password { get; set; }


    }
}