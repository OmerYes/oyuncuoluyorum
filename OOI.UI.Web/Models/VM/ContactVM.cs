using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class ContactVM : BaseVM
    {
        [Required(ErrorMessage ="Ad alanı boş bırakılamaz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz")]
        public string SurName { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        [Required(ErrorMessage = "Mesaj alanı boş bırakılamaz")]
        public string Message { get; set; }
    }
}