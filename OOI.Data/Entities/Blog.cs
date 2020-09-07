using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Data.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MainImage { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual BlogCategory Category { get; set; }
    }
}
