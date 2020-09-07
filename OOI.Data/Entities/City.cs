using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Data.Entities
{
    public class City : BaseEntity
    {
        public string PlateNumber { get; set; }
        public string Name { get; set; }
        public virtual List<WebUser> WebUsers { get; set; }
    }
}
