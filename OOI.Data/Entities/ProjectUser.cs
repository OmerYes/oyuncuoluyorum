using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Data.Entities
{
    public class ProjectUser : BaseEntity
    {
      
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }


        
        public int WebUserId { get; set; }
        [ForeignKey("WebUserId")]
        public virtual WebUser WebUser { get; set; }

    }
}
