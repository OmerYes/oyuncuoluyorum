using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Data.Entities
{
    public class Project : BaseEntity
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CoverPhoto { get; set; }
        public virtual List<ProjectPhoto> ProjectPhotos {get; set;}
        public int ProjectCategoryID { get; set; }
        [ForeignKey("ProjectCategoryID")]
        public virtual ProjectCategory ProjectCategory { get; set; }
        public virtual ICollection<ProjectUser> ProjectUsers { get; set; }
        public int CompanyID { get; set; }

    }
}
