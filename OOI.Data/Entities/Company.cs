using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Data.Entities
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LogoPath { get; set; }
        public string Password { get; set; }
        public int? CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual CompanyCategory CompanyCategory { get; set; }
        public int RejCount { get; set; }
        public int Credits { get; set; }

        public string ConfirmCode { get; set; }

        public string PwdCode { get; set; }
    }
}
