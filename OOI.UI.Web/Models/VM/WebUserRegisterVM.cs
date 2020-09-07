using OOI.Data.Entities;
using OOI.UI.Web.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class WebUserRegisterVM : BaseVM
    {
        [Required(ErrorMessage = "Lütfen e-mail adresinizi giriniz.")]
        [EmailAddress(ErrorMessage = "Lütfen e-mail adresinizi doğru girdiğinizden emin olunuz.")]
        [StringLength(50, ErrorMessage = "Lütfen e-mail adresinizi doğru girdiğinizden emin olunuz.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Lütfen telefon numaranızı giriniz.")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="Parola alanı boş bırakılamaz.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Parola eşleşmiyor!")]
        public string ConfirmPassword { get; set; }

        public string ConfirmCode { get; internal set; }

        public string RegistrationType { get; set; }

        [Required(ErrorMessage ="Sözleşme onaylanmak zorundadır")]
        public string sozlesme { get; set; }
    }
}