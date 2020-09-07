using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Data.Entities
{
    public class WebUser : BaseEntity
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

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

        public string PwdCode { get; set; }

        public bool IsRegisteredAagency{ get; set; }

        public virtual List<WebUserPhoto> WebUserPhotos { get; set; }

        public int? RejCount { get; set; }

        public int? CityID { get; set; }
        [ForeignKey("CityID")]
        public virtual City City { get; set; }

       
        public virtual List<UserExperience> UserExperiences { get; set; }

        public int Credits { get; set; }


        public virtual ICollection<ProjectUser> ProjectUsers { get; set; }
         
    }
}
