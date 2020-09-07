using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Data.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public int WebUserID { get; set; }
        [ForeignKey("WebUserID")]
        public virtual WebUser WebUser { get; set; }
    }
}
