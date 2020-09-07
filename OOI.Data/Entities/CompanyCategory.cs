﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Data.Entities
{
    public class CompanyCategory : BaseEntity
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Company> Companies { get; set; }
    }
}
