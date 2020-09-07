using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class WebUserFeaturesVM : BaseVM
    {
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public double? Weight { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public double? Height { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string DressSize { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string SkinColor { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string BodySize { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string ShoeSize { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string HairColor { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string HairStyle { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string EyeColor { get; set; }
    }
}