using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class ChangePasswordVM : BaseVM
    {
        [Required(ErrorMessage="Bu alan boş geçilemez.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Parola alanı boş bırakılamaz.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Parola tekrar alanı boş bırakılamaz.")]
        [Compare("NewPassword", ErrorMessage = "Parola eşleşmiyor!")]
        public string ConfirmPassword { get; set; }
    }
}