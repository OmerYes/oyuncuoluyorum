using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class ConfirmVM : BaseVM
    {
        [Required(ErrorMessage = "Aktivasyon kodunu giriniz.")]
        [StringLength(5, ErrorMessage = "Aktivasyon kodunu doğru girdiğinizden emin olunuz. Kod 5 haneli olmalıdır.")]
        public string ConfirmCode { get; set; }
    }
} 