using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Data.Entities
{
    public class Advert : BaseEntity
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime? FinishDate { get; set; }

        public decimal Price { get; set; }
        public virtual List<AdvertPhoto> AdvertPhotos { get; set; }
        public int AdvertCategoryID { get; set; }
        [ForeignKey("AdvertCategoryID")]
        public virtual AdvertCategory AdvertCategory { get; set; }

        public string AdvertPhone { get; set; }
        public string MainPhoto { get; set; }
    }
}
