using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Data.Entities
{
    public class AdvertPhoto : BaseEntity
    {
        public string ImagePath { get; set; }
        public int AdvertID { get; set; }
        [ForeignKey("AdvertID")]
        public virtual Advert Advert { get; set; }
    }
}
