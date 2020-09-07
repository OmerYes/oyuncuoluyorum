using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Data.Entities
{
    public class WebUserPhoto : BaseEntity
    {
        public string ImagePath { get; set; }
        public int WebUserID { get; set; }
        [ForeignKey("WebUserID")]
        public virtual WebUser WebUser { get; set; }
    }
}
