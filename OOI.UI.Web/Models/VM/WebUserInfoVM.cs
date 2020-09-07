using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class WebUserInfoVM : BaseVM
    {
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string LastName { get; internal set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string Email { get; internal set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public DateTime? BirthDate { get; internal set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string Gender { get; internal set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string DriverLicense { get; internal set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string Birthplace { get; internal set; }

        [Required(ErrorMessage = "")]
        public int? CityID { get; internal set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string University { get; internal set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string Branch { get; internal set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string Address { get; internal set; }
    }
}