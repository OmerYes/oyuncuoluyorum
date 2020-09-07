using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Data.Entities
{
    public class Promotion : BaseEntity
    {
        public string PromotionCode { get; set; }

        public double Price { get; set; }
    }
}
