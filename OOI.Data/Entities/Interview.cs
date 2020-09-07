using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Data.Entities
{
   public class Interview:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainPhoto { get; set; }

    }
}
