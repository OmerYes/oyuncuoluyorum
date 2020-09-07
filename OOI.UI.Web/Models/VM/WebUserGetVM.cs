using OOI.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Models.VM
{
    public class WebUserGetVM : BaseVM
    {
        public HttpPostedFileBase mainfile { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string BirthDateString { get; set; }

        public string Birthplace { get; set; }

        public string DriverLicense { get; set; }

        public string University { get; set; }

        public string Branch { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public double? Weight { get; set; }

        public double? Height { get; set; }

        public string DressSize { get; set; }

        public string SkinColor { get; set; }

        public string BodySize { get; set; }

        public string ShoeSize { get; set; }

        public string HairColor { get; set; }

        public string HairStyle { get; set; }

        public string EyeColor { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ProfilePhoto { get; set; }

        public string ConfirmCode { get; set; }

        public int? RejCount { get; set; }

        public int? CityID { get; set; }

        public string CityName { get; set; }
        public bool IsRegisteredAagency { get; set; }

        public List<WebUserPhotosVM> UserPhotos { get; set; }

        public List<SelectListItem> drpCities { get; set; }

        public List<UserExperienceVM> UserExperiences { get; set; }
    }
}