using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Data.Entities
{
    public class ProjectApply : BaseEntity
    {
        [Required]
        public int ProjectID { get; set; }
        public int WebUserID { get; set; }
        public DateTime ApplyDate { get; set; }
        public int ProjectApplyCategoryID { get; set; }
    }
}
