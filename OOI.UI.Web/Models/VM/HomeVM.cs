using OOI.UI.Web.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOI.UI.Web.Models.VM
{
    public class HomeVM
    {
        public List<ProjectVM> Projects { get; set; }
        public List<InterviewVM> Interviews { get; set; }
        public List<OpportunityVM> Opportunities { get; set; }
        public InterviewVM Interview { get; set; }
        public OpportunityVM Opportunity { get; set; }

    }
}